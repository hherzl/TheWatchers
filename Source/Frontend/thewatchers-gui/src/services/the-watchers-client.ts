import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { THE_WATCHERS_ENDPOINT } from '../settings';
import { ListResponse, SingleResponse } from './common';

@Injectable({
  providedIn: 'root'
})
export class TheWatchersClient {
  private http = inject(HttpClient);

  public getWatchers(): Observable<ListResponse<WatcherItemModel>> {
    return this.http.get<ListResponse<WatcherItemModel>>(`${THE_WATCHERS_ENDPOINT}/watchers`);
  }

  public getWatcher(id: number): Observable<SingleResponse<WatcherDetailsModel>> {
    return this.http.get<SingleResponse<WatcherDetailsModel>>(`${THE_WATCHERS_ENDPOINT}/watchers/${id}`);
  }

  public getResources(): Observable<ListResponse<ResourceItemModel>> {
    return this.http.get<ListResponse<ResourceItemModel>>(`${THE_WATCHERS_ENDPOINT}/resources`);
  }

  public getResourcesWatches(): Observable<ListResponse<ResourceWatchItemModel>> {
    return this.http.get<ListResponse<ResourceWatchItemModel>>(`${THE_WATCHERS_ENDPOINT}/resources-watches`);
  }
}

export class WatcherItemModel {
  public id!: number;
  public name!: string;
  public className!: string;
  public classGuid!: string;
}

export class WatcherDetailsModel {
  public id!: number;
  public name!: string;
  public description!: string;
  public className!: string;
  public classGuid!: string;

  public parameters!: WatcherParameterItemModel[];
}

export class WatcherParameterItemModel {
  public id!: number;
  public parameter!: string;
  public value!: string;
  public isDefault!: boolean;
  public description!: string;
}

export class ResourceItemModel {
  public id!: number;
  public name!: string;
  public resourceCategoryId!: number;
  public resourceCategory!: string;
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
