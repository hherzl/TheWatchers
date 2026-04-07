import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ResourceDetailsModel, TheWatchersClient, WatcherDetailsModel } from '../services/the-watchers-client';
import { map, Observable } from 'rxjs';

@Component({
  selector: 'app-resource-details',
  imports: [CommonModule, MatCardModule, MatButtonModule, MatIconModule],
  templateUrl: './resource-details.html',
  styleUrl: './resource-details.css',
})
export class ResourceDetails implements OnInit {
  private activatedRoute = inject(ActivatedRoute);
  private router = inject(Router);
  private theWatchersClient = inject(TheWatchersClient);
  public resource$!: Observable<ResourceDetailsModel>;

  ngOnInit(): void {
    this.activatedRoute.params.forEach((params: Params) => {
      let id = Number(params['id']);
      this.resource$ = this.theWatchersClient.getResource(id).pipe(map(result => result.model));
    });
  }

  public back(): void {
    this.router.navigate(['resources']);
  }
}
