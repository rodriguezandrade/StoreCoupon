import { Injectable } from '@angular/core';
import { BaseService } from './generics/base.service';
import { Store } from '../models/store';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from '../models/utils/appSettings';
import { StoreSerializer } from '../models/serializers/storeSerializers';

@Injectable({
  providedIn: 'root'
})
export class StoreService extends  BaseService<Store>{

  constructor(httpClient:HttpClient) {
    super(httpClient, 
      `${AppSettings.API_ENDPOINT}`, 
      new StoreSerializer());
  }
}
