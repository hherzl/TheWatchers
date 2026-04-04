import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { THE_WATCHERS_ENDPOINT } from '../settings';
import { ListResponse } from './common';

@Injectable({
  providedIn: 'root'
})
export class TheWatchersClient {
  private http = inject(HttpClient);
  
  public getResourcesWatches(): Observable<ListResponse<ResourceWatchItemModel>> {
    return this.http.get<ListResponse<ResourceWatchItemModel>>(`${THE_WATCHERS_ENDPOINT}/resources-watches`);
  }
  public getWatchers(): Observable<ListResponse<WatcherItemModel>> {
    return this.http.get<ListResponse<WatcherItemModel>>(`${THE_WATCHERS_ENDPOINT}/watchers`);
  }
}

export class ResourceWatchItemModel {
  public id!: number;
  public resourceId!: number;
  public resource!: string;
  public resourceCategoryId!: number;
  public resourceCategory!: string;
  public assemblyQualifiedName!: string;
  public environmentId!: number;
  public environment!: string;
  public successful!: boolean;
  public watchCount!: number;
  public lastWatch!: Date;
  public interval!: number;
}

export class WatcherItemModel {
  public id!: number;
  public name!: string;
  public className!: string;
  public classGuid!: string;
}
