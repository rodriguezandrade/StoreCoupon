import { Injectable, OnInit } from "@angular/core";
import { GenericsService } from "./generics.service";
import { Category } from "../models/category";
import { HttpClient } from "@angular/common/http";
import { AppSettings } from "../models/utils/appSettings";

@Injectable({
  providedIn: "root"
})
export class CategoryService extends GenericsService<Category> {
  constructor(httpClient: HttpClient) {
    super(
      httpClient, 
      `${AppSettings.API_ENDPOINT}`);
  }
}
