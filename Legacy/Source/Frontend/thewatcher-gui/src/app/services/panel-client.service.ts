import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PANEL_API_ENDPOINT } from 'src/settings';
import { ListResponse } from './common';

@Injectable({
  providedIn: 'root'
})
export class PanelClientService {

  private readonly endpoint: string;

  constructor(private http: HttpClient) {
    this.endpoint = `${PANEL_API_ENDPOINT}/api/v1`;
  }

  public getWatchers(): Observable<ListResponse<WatcherItemModel>> {
    const url = `${this.endpoint}/watcher`;
    return this.http.get<ListResponse<WatcherItemModel>>(url);
  }

  public getResources(): Observable<ListResponse<ResourceItemModel>> {
    const url = `${this.endpoint}/resource`;
    return this.http.get<ListResponse<ResourceItemModel>>(url);
  }
}

export class WatcherItemModel {
  public id!: number;
  public name!: string;
  public description!: string;
  public className!: string;
}

export class ResourceItemModel {
  public id!: number;
  public name!: string;
  public resourceCategoryId!: number;
  public resourceCategory!: string;
}
