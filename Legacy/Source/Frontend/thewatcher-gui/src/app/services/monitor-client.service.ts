import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MONITOR_API_ENDPOINT } from 'src/settings';
import { ListResponse } from './common';

@Injectable({
  providedIn: 'root'
})
export class MonitorClientService {

  private endpoint: string;

  constructor(private http: HttpClient) {
    this.endpoint = `${MONITOR_API_ENDPOINT}/api/v1`;
  }

  public getMonitor(): Observable<ListResponse<ResourceWatchItemModel>> {
    const url = `${this.endpoint}/monitor`;
    return this.http.get<ListResponse<ResourceWatchItemModel>>(url);
  }
}

export class ResourceWatchItemModel {
  public id!: number;
  public resourceId!: number;
  public resource!: string;
  public resourceCategoryId!: number;
  public resourceCategory!: string;
  public environmentId!: number;
  public environment!: string;
  public successful!: boolean;
  public watchCount!: number;
  public lastWatch!: Date;
  public interval!: number;
}
