import { Injectable, inject } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { JsonPipe } from '@angular/common';
import { Owner } from '../models/owner';



@Injectable({
  providedIn: 'root'
})
export class Rest {
  wsUrl: string='api/';
  constructor(public http:HttpClient) { 
    
  }

  GetAll(apiurl:string) : Observable <any> {
      return this.http.get<any[]>(this.wsUrl+apiurl);
  }

  GetById(apiurl:string) : Observable <any>{
    return this.http.get<any>(this.wsUrl+apiurl);
  }

  Post(model:Owner,apiurl:string) : Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type' : 'application/json'
      })};
      let x:number = +model.telephone;
      model.telephone= x;
      console.log(JSON.stringify(model));
      
    
    return this.http.post(this.wsUrl+apiurl, JSON.stringify(model),httpOptions);    
  }

  Update(model,apiurl:string) : Observable<any> {
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type' : 'application/json'
        })};
        return this.http.put(this.wsUrl+apiurl, JSON.stringify(model),httpOptions)
    }

    Delete(apiurl:string) : Observable<any>{
      return this.http.delete(this.wsUrl+apiurl);
    }
  

}
