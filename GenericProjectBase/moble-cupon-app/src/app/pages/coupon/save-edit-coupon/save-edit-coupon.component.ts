import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Coupon, CouponStoreService } from '../store';
import { ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-save-edit-coupon',
  templateUrl: './save-edit-coupon.component.html',
  styleUrls: ['./save-edit-coupon.component.scss'],
})
export class SaveEditCouponComponent implements OnInit {

  coupon: Coupon[] = [];

  cuponForm: FormGroup;
  get f() { return this.cuponForm.controls }
  productId = 0;

  constructor(
    private router: Router,
    private stc  : CouponStoreService,
    private fb: FormBuilder
  ) {
    this.cuponForm = this.fb.group( 
      {
        name: ["", [Validators.required] ],
        status: ["", [Validators.required] ],
        discount: ["", [Validators.required] ], 
      }
     );
   }

  ngOnInit() {}

  saveCoupon(){
    console.log( this.cuponForm.value, 'coupon form' );
    let data : Coupon = this.cuponForm.value;
    this.editCoupon ( 3, data );



  }

  editCoupon( id: number, data: Coupon ){
    this.stc.editCoupon( id, data ).then(
      res => {
        console.log( res, 'data al editar cupon ' );
        let index = this.stc.filtrarIndex( id );
        this.stc.actualizarItem( index , res );
        this.stc.coupon =  this.stc.filtrarVacio( this.stc.coupon );
        console.log( this.stc.coupon, 'lista');
        this.router.navigate( ['/coupon'] );


      }
    )
  }

  createCoupon( data: Coupon ){
    this.stc.newCoupon( data ).then(
      res => {
        console.log( res , 'nuevo cupon en el componente' );
        this.addCouponToList(res);
        this.router.navigate( ['/coupon'] );
      } 
    );
  }

  addCouponToList( data: Coupon ){
    this.coupon.push(data);
    this.stc.coupon.push( this.coupon[0] );
    this.stc.coupon =  this.stc.filtrarVacio( this.stc.coupon );
  }

}
