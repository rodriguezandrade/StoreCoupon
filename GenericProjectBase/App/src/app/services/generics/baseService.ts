import { Serializer } from "../../models/utils/serializer";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { HttpClient } from "@angular/common/http";
import { Resource } from "../../models/utils/resource";
import { QueryOptions } from "./queryOptions";

export class BaseService<T extends Resource> {
  constructor(
    private httpClient: HttpClient,
    private url: string,
    private endpoint: string,
    private serializer: Serializer
  ) {}

  public create(item: T): Observable<T> {
    return this.httpClient
      .post<T>(`${this.url}/${this.endpoint}`, this.serializer.toJson(item))
      .pipe(map(data => this.serializer.fromJson(data) as T));
  }

  public update(item: T): Observable<T> {
    return this.httpClient
      .put<T>(
        `${this.url}/${this.endpoint}/${item.id}`,
        this.serializer.toJson(item)
      )
      .pipe(map(data => this.serializer.fromJson(data) as T));
  }

  read(id: number): Observable<T> {
    return this.httpClient
      .get(`${this.url}/${this.endpoint}/${id}`)
      .pipe(map((data: any) => this.serializer.fromJson(data) as T));
  }

  list(queryOptions: QueryOptions): Observable<T[]> {
    return this.httpClient
      .get(`${this.url}/${this.endpoint}?${queryOptions.toQueryString()}`)
      .pipe(map((data: any) => this.convertData(data.items)));
  }

  delete(id: number) {
    return this.httpClient.delete(`${this.url}/${this.endpoint}/${id}`);
  }

  private convertData(data: any): T[] {
    return data.map(item => this.serializer.fromJson(item));
  }
}
