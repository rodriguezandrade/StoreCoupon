import { Serializer } from "../../models/utils/serializer";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Resource } from "../../models/utils/resource";
import { QueryOptions } from "./query.options";
import { Input } from '@angular/core';

export class BaseService<T extends Resource> {
  @Input() endpoint:string;
  constructor(
    private httpClient: HttpClient,
    private url: string,
    private serializer: Serializer
  ) {}

  public create(item: T): Observable<T> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type' : 'application/json'
      })};
      console.log(this.serializer.toJson(item, "new"));
      
    return this.httpClient
      .post<T>(`${this.url}/${this.endpoint}`, this.serializer.toJson(item, "new"),httpOptions)
      .pipe(map(data => this.serializer.fromJson(data) as T));
  }

  public update(item: T): Observable<T> {
    return this.httpClient
      .put<T>(
        `${this.url}/${this.endpoint}`,
        this.serializer.toJson(item, "edit")
      )
      .pipe(map(data => this.serializer.fromJson(data) as T));
  }

  read(id: string): Observable<T> {
    return this.httpClient
      .get(`${this.url}/${this.endpoint}/${id}`)
      .pipe(map((data: any) => this.serializer.fromJson(data) as T));
  }

  list(queryOptions: QueryOptions): Observable<T[]> {
    return this.httpClient
      .get(`${this.url}/${this.endpoint}?${queryOptions.toQueryString()}`)
      .pipe(map((data: any) => this.convertData(data.items)));
  }

  listWithoutFilter(): Observable<T[]> {   
    return this.httpClient
    .get(`${this.url}/${this.endpoint}`)
    .pipe(map((data: any) => this.convertData(data)));
}

  delete(id: string) {
    return this.httpClient.delete(`${this.url}/${this.endpoint}/${id}`);
  }

  private convertData(data: any): T[] {
    return data.map(item => this.serializer.fromJson(item));
  }
}
