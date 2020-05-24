import { Injectable } from '@angular/core';
import { BehaviorSubject, pipe} from 'rxjs';
import { map } from 'rxjs/operators';
import { CouponManagerService } from './coupon-manager.service';
import { Coupon } from './coupon-interface';

@Injectable({
  providedIn: 'root'
})

export class CouponStoreService {

  private readonly _coupon = new BehaviorSubject< Coupon[]>([]);
  readonly  coupon$ = this._coupon.asObservable();

  readonly  couponList$ = this. coupon$
  .pipe(
    map(
      res => {
        return this.filtrarVacio( res );
      }
    )
  );

  get  coupon() :  Coupon[]{
    return this._coupon.getValue();
  }
  set  coupon( val:  Coupon[] ){
    this._coupon.next( val );
  }
  constructor( private couponManagerService: CouponManagerService ) { }

  //.....................................add new  coupon
  async editCoupon( id:  number, data:  Coupon ) {
    let newCoupon =  await this.couponManagerService.editCoupon( id, data )
    .toPromise();
    return newCoupon;
  }

  //.....................................add new  coupon
  async newCoupon( data:  Coupon ) {
  let newCoupon =  await this.couponManagerService.addCoupon( data )
  .toPromise();
  return newCoupon;
  }

  //.....................................get list of  coupon
  async getCouponList(){
    let  couponList = await this.couponManagerService.couponList()
    .toPromise();
    this.coupon.push( couponList); 
  }

  actualizarItem( index: number, newItem: Coupon ){
    if ( ~ index ) {
      this.coupon[0][index] = newItem;
    } 
  }

  filtrarIndex( id: number ){
    let index : number = null;
    this.coupon = this.filtrarVacio(this.coupon);
    this.coupon.forEach(
      ( res, i ) =>{
        console.log( res, i );
        if ( res.id === id ) {
          index = i;
        }
      }
    ); 
    return index;
  }

  filtrarVacio( array:  Coupon[] ){
    var filtered = array.filter(function (el) {
      return el != null || undefined;
    });
    
    return this.AplanarArray(filtered);
  }

  AplanarArray(arr1:  Coupon[]) {
    return arr1.reduce((acc, val) => Array.isArray(val) ? acc.concat(this.AplanarArray(val)) : acc.concat(val), []);
 }
  
}
