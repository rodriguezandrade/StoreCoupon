import { Component, OnInit } from '@angular/core';
import { Product, ProductStoreService } from '../store/index';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss'],
})
export class ProductListComponent implements OnInit {
  
  productList : Product[];

  constructor(
    private productStore: ProductStoreService,
  ) { this.listProduct(); }

  ngOnInit() {}

  async productListChanges(){
    await this.productStore.productList$.subscribe(
      res => { 
        console.log( res, 'ista en el componente' );
        this.productList = res;        
      }
    )
  }

  async listProduct(){
    console.log( 'product list event run ' );
    await this.productStore.getProductList().then(
      () => ( this.productListChanges() )
    );
  } 

  test(){
    console.log( this.productStore.product  );
  }

}
