import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { Product } from './product-interface';

const httpOptions = {
  headers: new HttpHeaders(
    {
      'Content-Type' : 'application/json'
    }
  )
}

@Injectable({
  providedIn: 'root'
})

export class ProductManagerService {

  produtList: Product[]

  constructor( private http : HttpClient ) { }

  //...........................................Nuevo Producto
  addProduct( product: Product ): Observable<Product>{
    return this.http.post<Product>('/api/product/save', product, httpOptions )
    .pipe(
      map( 
        res => {
          console.log( res, 'data en el servicio')
          return res;
        }
      )
    );
  }
  //...........................................nuevo producto

  //...........................................Lista de productos
  productList() : Observable<Product>{
    return this.http.get<Product>('/api/product/get', httpOptions )
    .pipe(
      map( res => {
        console.log( 'procuct list en servicio', res );
        return res;
      } )
    );
  }
  //...........................................lista de productos

}
