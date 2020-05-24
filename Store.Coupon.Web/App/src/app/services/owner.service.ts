import { Injectable, Inject, Input } from '@angular/core';
import { BaseService } from './generics/base.service';
import { HttpClient } from "@angular/common/http";
import { Owner } from '../models/owner';
import { AppSettings } from '../models/utils/appSettings';
import { OwnerSerializer } from '../models/serializers/ownerSerializer';

@Injectable({
  providedIn: 'root'
})
export class OwnerService extends BaseService<Owner> {
  constructor(httpClient: HttpClient) {
    super(
      httpClient, 
      `${AppSettings.API_ENDPOINT}`, 
      new OwnerSerializer());
  }
}
