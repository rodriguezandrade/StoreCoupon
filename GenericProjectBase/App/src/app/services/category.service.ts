import { Injectable } from '@angular/core';
import { BaseService } from './generics/baseService';
import { Category } from '../models/category';
import { Serializer } from '../models/utils/serializer';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends BaseService<Category> {

  constructor(httpClient:HttpClient) {  
    super(httpClient, 'http://',  'categories', this.serializer:Seria)
}
