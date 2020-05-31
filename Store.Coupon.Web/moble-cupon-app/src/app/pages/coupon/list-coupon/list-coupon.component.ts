import { Component, OnInit } from '@angular/core';
import { CouponStoreService, Coupon } from '../store/index';
@Component({
  selector: 'app-list-coupon',
  templateUrl: './list-coupon.component.html',
  styleUrls: ['./list-coupon.component.scss'],
})
export class ListCouponComponent implements OnInit {
  couponList : Coupon[];
  constructor( private stProd: CouponStoreService ) { }

  ngOnInit() { this.getListCoupons() }

  onSwipe( action ){
    console.log( action, 'event swipe run');
  }

  async listeningCouponsList(){
    await this.stProd.couponList$.subscribe(
      res => {
        console.log( res, 'lista de copones en el componente' );
        this.couponList = res;
      }
    )
  }

  getListCoupons(){
    this.stProd.getCouponList().then(
      () => ( this.listeningCouponsList() )
    )
  }

}
