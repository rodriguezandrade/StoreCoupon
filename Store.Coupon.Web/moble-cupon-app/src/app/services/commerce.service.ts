import { Injectable, OnInit } from "@angular/core";
import { GenericsService } from "./generics.service";
import { Commerce } from "../models/commerce";
import { HttpClient } from "@angular/common/http";
import { AppSettings } from "../models/utils/appSettings";

@Injectable({
  providedIn: "root"
})
export class  CommerceService extends GenericsService<Commerce> {
  constructor(httpClient: HttpClient) {
    super(
      httpClient, 
      `${AppSettings.API_ENDPOINT}`);
  }
}
