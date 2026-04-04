import { AfterViewInit, Component, inject, ViewChild } from '@angular/core';
import { MatTableModule, MatTable } from '@angular/material/table';
import { MatPaginatorModule, MatPaginator } from '@angular/material/paginator';
import { MatSortModule, MatSort } from '@angular/material/sort';
import { WatchersListDataSource } from './watchers-list-datasource';
import { TheWatchersClient, WatcherItemModel } from '../services/the-watchers-client';
import { Router } from '@angular/router';

@Component({
  selector: 'app-watchers-list',
  templateUrl: './watchers-list.component.html',
  styleUrl: './watchers-list.component.css',
  imports: [MatTableModule, MatPaginatorModule, MatSortModule],
})
export class WatchersListComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<WatcherItemModel>;
  dataSource = new WatchersListDataSource([]);

  private router = inject(Router);
  private theWatchersClient = inject(TheWatchersClient);
  
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name', 'className'];

  ngAfterViewInit(): void {
    this.theWatchersClient.getWatchers().subscribe(result => {
      this.dataSource = new WatchersListDataSource(result.model);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      
      this.table.dataSource = this.dataSource;
    });
  }

  details(item: WatcherItemModel): void {
    this.router.navigate([`watchers/${item.id}`]);
  }
}
