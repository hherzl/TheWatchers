import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { TheWatchersClient, WatcherDetailsModel } from '../services/the-watchers-client';
import { map, Observable } from 'rxjs';

@Component({
  selector: 'app-watcher-details',
  imports: [CommonModule, MatCardModule, MatButtonModule, MatIconModule],
  templateUrl: './watcher-details.component.html',
  styleUrl: './watcher-details.component.css',
})
export class WatcherDetailsComponent implements OnInit {
  private activatedRoute = inject(ActivatedRoute);
  private router = inject(Router);
  private theWatchersClient = inject(TheWatchersClient);
  public watcher$!: Observable<WatcherDetailsModel>;

  ngOnInit(): void {
    this.activatedRoute.params.forEach((params: Params) => {
      let id = Number(params['id']);
      this.watcher$ = this.theWatchersClient.getWatcher(id).pipe(map(result => result.model));
    });
  }

  public back(): void {
    this.router.navigate(['watchers']);
  }
}
