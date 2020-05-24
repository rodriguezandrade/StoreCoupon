import { Injectable, OnInit } from "@angular/core";
import { BaseService } from "./generics/base.service";
import { Category } from "../models/category";
import { HttpClient } from "@angular/common/http";
import { CategorySerializer } from "../models/serializers/categorySerializer";
import { AppSettings } from "../models/utils/appSettings";

@Injectable({
  providedIn: "root"
})
export class CategoryService extends BaseService<Category> {
  constructor(httpClient: HttpClient) {
    super(
      httpClient, 
      `${AppSettings.API_ENDPOINT}`,  
      new CategorySerializer());
  }
}
