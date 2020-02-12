import { HttpClient } from '@angular/common/http';
import { Resource } from 'src/app/models/utils/resource';
import { Serializer } from 'src/app/models/utils/serializer';
import { Observable } from 'rxjs';
import { QueryOptions } from './query.options';
import { map } from 'rxjs/operators';

export class SubBaseService<T extends Resource> {
    constructor(
      private httpClient: HttpClient,
      private url: string,
      private parentEndpoint: string,
      private endpoint: string,
      private serializer: Serializer) {  }
  
    public create(item: T): Observable<T> {
    return this.httpClient
      .post<T>(`${this.url}/${this.parentEndpoint}/${item.parentId}/${this.endpoint}`,
        this.serializer.fromJson(item))
      .pipe(map((data: any) => this.serializer.fromJson(data) as T));
    }
  
    public update(item: T): Observable<T> {
      return this.httpClient
        .put<T>(`${this.url}/${this.parentEndpoint}/${item.parentId}/${this.endpoint}/${item.id}`,
          this.serializer.toJson(item))
        .pipe(map((data: any) => this.serializer.fromJson(data) as T));
    }
  
    read(parentId: number, id: number): Observable<T> {
      return this.httpClient
        .get(`${this.url}/${this.parentEndpoint}/${parentId}/${this.endpoint}/${id}`)
        .pipe(map((data: any) => this.serializer.fromJson(data) as T));
    }
  
    list(parentId: number, queryOptions: QueryOptions): Observable<T[]> {
      return this.httpClient
        .get(`${this.url}/${this.parentEndpoint}/${parentId}/${this.endpoint}?${queryOptions.toQueryString()}`)
        .pipe(map((data: any) => this.convertData(data.items)));
    }
  
    delete(parentId: number, id: number) {
      return this.httpClient
        .delete(`${this.url}/${this.parentEndpoint}/${parentId}/${this.endpoint}/${id}`);
    }
  
    protected convertData(data: any): T[] {
      return data.map(item => this.serializer.fromJson(item));
    }
  }