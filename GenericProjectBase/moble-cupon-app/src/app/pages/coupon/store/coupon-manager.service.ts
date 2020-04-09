import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { Coupon } from './coupon-interface';

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

export class CouponManagerService {

  constructor( private http : HttpClient ) { }

    //...........................................Nuevo Producto
    editCoupon( id: number,  product:  Coupon ): Observable< Coupon>{
      return this.http.put<Coupon>(`/api-cupon/Coupons/${id}`, product, httpOptions )
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
  
  //...........................................Nuevo Producto
  addCoupon( product:  Coupon ): Observable< Coupon>{
    return this.http.post< Coupon>('/api-cupon/Coupons', product, httpOptions )
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
  couponList() : Observable< Coupon>{
    return this.http.get< Coupon>('/api-cupon/Coupons', httpOptions )
    .pipe(
      map( res => {
        console.log( 'procuct list en servicio', res );
        return res;
      } )
    );
  }
  //...........................................lista de productos

}
