import { AfterViewInit, Component, inject, ViewChild } from '@angular/core';
import { MatTableModule, MatTable } from '@angular/material/table';
import { MatPaginatorModule, MatPaginator } from '@angular/material/paginator';
import { MatSortModule, MatSort } from '@angular/material/sort';
import { ResourcesListDataSource } from './resources-list-datasource';
import { Router } from '@angular/router';
import { ResourceItemModel, TheWatchersClient } from '../services/the-watchers-client';

@Component({
  selector: 'app-resources-list',
  templateUrl: './resources-list.component.html',
  styleUrl: './resources-list.component.css',
  imports: [MatTableModule, MatPaginatorModule, MatSortModule],
})
export class ResourcesListComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<ResourceItemModel>;
  dataSource = new ResourcesListDataSource([]);

  private router = inject(Router);
  private theWatchersClient = inject(TheWatchersClient);

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name', 'resourceCategory'];

  ngAfterViewInit(): void {
    this.theWatchersClient.getResources().subscribe(result => {
      this.dataSource = new ResourcesListDataSource(result.model);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      this.table.dataSource = this.dataSource;
    });
  }

  details(item: ResourceItemModel): void {
    this.router.navigate([`resources/${item.id}`]);
  }
}
