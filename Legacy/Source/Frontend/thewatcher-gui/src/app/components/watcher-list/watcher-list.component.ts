import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { PanelClientService, WatcherItemModel } from 'src/app/services/panel-client.service';
import { WatcherListDataSource } from './watcher-list-datasource';

@Component({
  selector: 'app-watcher-list',
  templateUrl: './watcher-list.component.html',
  styleUrls: ['./watcher-list.component.css']
})
export class WatcherListComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<WatcherItemModel>;
  dataSource!: WatcherListDataSource;
  
  displayedColumns = ['id', 'name'];

  constructor(private panelClient: PanelClientService) {
  }

  ngAfterViewInit(): void {
    this.panelClient.getWatchers().subscribe(result => {
      this.dataSource = new WatcherListDataSource(result.model);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      this.table.dataSource = this.dataSource;
    });
  }
}
