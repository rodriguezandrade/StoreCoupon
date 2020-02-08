import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class GenericService {
  endpoint: string = '';

  constructor(
    private http: HttpClient
  ) {}

  // CREATE
  create<T>(model: T | any, objToCreate: T | any): Observable<T | T[]> {
    return this.http.post<T | T[]>(`${this.endpoint}/${model.tableName}`, objToCreate);
  }

  // READ
  read<T>(model: T | any): Observable<T | T[]> {
    return this.http.get<T | T[]>(`${this.endpoint}/${model.tableName}`);
  }

  // UPDATE
  update<T>(model: T | any, objToUpdate: T | any): Observable<T | T[]> {
    return this.http.patch<T | T[]>(`${this.endpoint}/${model.tableName}/${objToUpdate.id}`,  objToUpdate);
  }

  // DELETE 
  delete<T>(model: T | any, objToDelete): Observable<T | T[]> {
    return this.http.delete<T | T[]>(`${this.endpoint}/${model.tableName}/${objToDelete.id}`);
  }
}