import { Injectable, OnInit } from "@angular/core";
import { BaseService } from "./generics/base.service";
import { Product } from "../models/product";
import { HttpClient } from "@angular/common/http";
import { ProductSerializer } from "../models/serializers/productSerializer";
import { AppSettings } from "../models/utils/appSettings";

@Injectable({
  providedIn: "root"
})
export class ProductService extends BaseService<Product> {
  constructor(httpClient: HttpClient) {
    super(
      httpClient, 
      `${AppSettings.API_ENDPOINT}`,  
      new ProductSerializer());
  }
}
