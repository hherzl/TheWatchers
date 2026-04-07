import { Component, inject, OnInit } from '@angular/core';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { map, combineLatest, Observable, shareReplay, BehaviorSubject } from 'rxjs';
import { AsyncPipe, DatePipe } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import * as signalR from '@microsoft/signalr';
import { ResourceWatchItemModel, TheWatchersClient } from '../services/the-watchers-client';
import { CardModel } from './card-model';
import { THE_WATCHERS_ENDPOINT } from '../settings';

@Component({
  selector: 'app-joe-viewer',
  templateUrl: './joe-viewer.component.html',
  styleUrl: './joe-viewer.component.css',
  standalone: true,
  imports: [
    AsyncPipe,
    DatePipe,
    MatGridListModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
  ],
})
export class JoeViewerComponent implements OnInit {
  private breakpointObserver = inject(BreakpointObserver);
  private theWatchersClient = inject(TheWatchersClient);

  /** UI state */
  private isHandset$ = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay({ bufferSize: 1, refCount: true })
    );

  private resourcesSubject = new BehaviorSubject<ResourceWatchItemModel[]>([]);
  resourcesWatches$ = this.resourcesSubject.asObservable();

  /** ViewModel */
  cards$: Observable<CardModel[]> = combineLatest([
    this.resourcesWatches$,
    this.isHandset$
  ]).pipe(
    map(([resourcesWatches, isHandset]) =>
      resourcesWatches.map(resourceWatch => ({
        id: resourceWatch.id,
        resource: resourceWatch.resource,
        resourceCategory: resourceWatch.resourceCategory,
        environment: resourceWatch.environment,
        successful: resourceWatch.successful,
        watchCount: resourceWatch.watchCount,
        lastWatch: resourceWatch.lastWatch,
        cols: isHandset ? 2 : 1,
        rows: isHandset ? 2 : 1,
      }))
    )
  );

  private hubConnection!: signalR.HubConnection;

  ngOnInit(): void {
    this.theWatchersClient.getResourcesWatches()
      .pipe(map(res => res.model))
      .subscribe(data => this.resourcesSubject.next(data));

    this.startConnection();
  }

  /** SignalR (side-effect isolated) */
  private startConnection(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${THE_WATCHERS_ENDPOINT}/monitorhub`)
      .withAutomaticReconnect()
      .build();

    this.hubConnection.start()
      .then(() => this.addReceiveResourceWatchListener())
      .catch(err => console.error(err));
  }

  private addReceiveResourceWatchListener(): void {
    this.hubConnection.on('receiveResourceWatch', (data) => {
      console.log(data);
      const current = this.resourcesSubject.value;
      const index = current.findIndex(item => item.id === data.id);
      if (index === -1) {
        this.resourcesSubject.next([...current, data]);
        return;
      }

      const existing = current[index];
      if (JSON.stringify(existing) === JSON.stringify(data)) {
        return;
      }

      const updated = [...current];
      updated[index] = {
        ...existing,
        ...data
      };

      this.resourcesSubject.next(updated);
    });
  }
}
