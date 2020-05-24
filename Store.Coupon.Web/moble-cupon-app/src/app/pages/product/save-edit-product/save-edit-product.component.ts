import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ValidationService } from '../../../commons-web/validator/validation.service';
import { Product, ProductStoreService } from '../store/index';
import { ActivatedRoute, Router} from '@angular/router'
@Component({
  selector: 'app-save-edit-product',
  templateUrl: './save-edit-product.component.html',
  styleUrls: ['./save-edit-product.component.scss'],
})
export class SaveEditProductComponent implements OnInit {
 
  product: Product[] = [];

  productForm: FormGroup;
  get f() { return this.productForm.controls }
  productId = 0;

  constructor(
    private productStoreService: ProductStoreService,
    private router: Router,
    private readonly route: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.productForm = this.fb.group( 
      {
        name: ["", [Validators.required] ],
        description: ["", [Validators.required] ],
        price: ["", [Validators.required] ], 
      }
     );
   }

  ngOnInit() {
  } 

  saveProduct(){
    console.log( this.productForm.value, 'product form' );
    let data : Product = this.productForm.value;
    this.productStoreService.newProduct( data ).then(
      res => {
        this.product.push(res);
        console.log( this.product, 'modelo retornado al guardar new ');
        this.productStoreService.product.push( this.product[0] );
        this.productStoreService.product =  this.productStoreService.filtrarVacio( this.productStoreService.product );
        console.log( this.productStoreService.product  );
        this.router.navigate( ['/product'] );
      } 
    );
  }

}
