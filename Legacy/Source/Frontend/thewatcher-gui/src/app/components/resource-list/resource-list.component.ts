import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { ResourceListDataSource } from './resource-list-datasource';
import { PanelClientService, ResourceItemModel } from 'src/app/services/panel-client.service';

@Component({
  selector: 'app-resource-list',
  templateUrl: './resource-list.component.html',
  styleUrls: ['./resource-list.component.css']
})
export class ResourceListComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<ResourceItemModel>;
  dataSource!: ResourceListDataSource;
  
  displayedColumns = ['id', 'name', 'resourceCategory'];

  constructor(private panelClient: PanelClientService) {
  }

  ngAfterViewInit(): void {
    this.panelClient.getResources().subscribe(result => {
      this.dataSource = new ResourceListDataSource(result.model);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      this.table.dataSource = this.dataSource;
    });
  }
}
