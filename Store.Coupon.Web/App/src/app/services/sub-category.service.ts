import { Injectable } from "@angular/core";
import { BaseService } from "./generics/base.service"; 
import { HttpClient } from "@angular/common/http"; 
import { AppSettings } from "../models/utils/appSettings";
import { SubCategorySerializer } from '../models/serializers/subCategorySerializer';
import { SubCategoryDto } from '../models/Dto/subCategoryDto';

@Injectable({
  providedIn: "root"
})
export class SubCategoryService extends BaseService<SubCategoryDto> {
  
  constructor(httpClient: HttpClient) {
    super(
      httpClient, 
      `${AppSettings.API_ENDPOINT}`, 
      new SubCategorySerializer());
  }
}
