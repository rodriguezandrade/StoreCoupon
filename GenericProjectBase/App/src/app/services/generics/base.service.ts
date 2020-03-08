import { Serializer } from "../../models/utils/serializer";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Resource } from "../../models/utils/resource";
import { QueryOptions } from "./query.options";
import { Actions } from 'src/app/utils/enums/actions';


export class BaseService<T extends Resource> {
  constructor(
    private httpClient: HttpClient,
    private url: string,
    private serializer: Serializer
  ) {}

  public create(item: T, endpoint:string): Observable<T> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type' : 'application/json'
      })};
      
    return this.httpClient
      .post<T>(`${this.url}/${endpoint}`, this.serializer.toJson(item, Actions.New),httpOptions)
      .pipe(map(data => this.serializer.fromJson(data) as T));
  }

  public update(item: T, endpoint:string): Observable<T> {
    return this.httpClient
      .put<T>(
        `${this.url}/${endpoint}`,
        this.serializer.toJson(item, Actions.Edit)
      )
      .pipe(map(data => this.serializer.fromJson(data) as T));
  }

  read(id: string, endpoint:string): Observable<T> {
    return this.httpClient
      .get(`${this.url}/${endpoint}/${id}`)
      .pipe(map((data: any) => this.serializer.fromJson(data) as T));
  }

  list(queryOptions: QueryOptions, endpoint:string): Observable<T[]> {
    return this.httpClient
      .get(`${this.url}/${endpoint}?${queryOptions.toQueryString()}`)
      .pipe(map((data: any) => this.convertData(data.items)));
  }

  listWithoutFilter(endpoint:string): Observable<T[]> {   
    return this.httpClient
    .get(`${this.url}/${endpoint}`)
    .pipe(map((data: any) => this.convertData(data)));
}

  delete(id: string, endpoint:string) {
    return this.httpClient.delete(`${this.url}/${endpoint}/${id}`);
  }

  private convertData(data: any): T[] {
    return data.map(item => this.serializer.fromJson(item));
  }
}
