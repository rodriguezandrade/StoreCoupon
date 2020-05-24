import { Injectable } from '@angular/core';
import { Resource } from "../models/utils/resource";
import { QueryOptions } from "./query.options";
import { Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class GenericsService <T extends Resource> {

  constructor(
    private httpClient: HttpClient,
    private url: string,
  ) { }

  details(id: number, endpoint:string): Observable<T> {
    return this.httpClient
      .get(`${this.url}/${endpoint}/${id}`)
      .pipe(
            map(
                (data: any) => { return data }
              )
           );
  }

  listWithoutFilter(endpoint:string): Observable<T[]> {   
    return this.httpClient
    .get(`${this.url}/${endpoint}`)
    .pipe(
          map(
              (data: any) => { return data }
             )
        );
} 

}
