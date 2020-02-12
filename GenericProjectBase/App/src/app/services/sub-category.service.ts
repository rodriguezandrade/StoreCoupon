import { Injectable } from "@angular/core";
import { BaseService } from "./generics/base.service"; 
import { HttpClient } from "@angular/common/http"; 
import { AppSettings } from "../models/utils/appSettings";
import { SubCategory } from '../models/subcategory';
import { SubCategorySerializer } from '../models/serializers/subCategorySerializer';

@Injectable({
  providedIn: "root"
})
export class SubCategoryService extends BaseService<SubCategory> {
  
  constructor(httpClient: HttpClient) {
    super(
      httpClient, 
      `${AppSettings.API_ENDPOINT}`, 
      "subCategories/getAll", 
      new SubCategorySerializer());
  }
}
