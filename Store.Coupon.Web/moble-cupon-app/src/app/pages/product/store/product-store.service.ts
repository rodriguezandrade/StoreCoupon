import { Injectable } from '@angular/core';
import { BehaviorSubject, pipe} from 'rxjs';
import { map } from 'rxjs/operators';
import { ProductManagerService } from './product-manager.service';
import { Product } from './product-interface';

@Injectable({
  providedIn: 'root'
})

export class ProductStoreService {

  private readonly _product = new BehaviorSubject<Product[]>([]);
  readonly product$ = this._product.asObservable();

  readonly productList$ = this.product$
  .pipe(
    map(
      res => {
        return this.filtrarVacio( res );
      }
    )
  );

  get product() : Product[]{
    return this._product.getValue();
  }
  set product( val: Product[] ){
    this._product.next( val );
  }
  constructor( private productManagerService: ProductManagerService ) { }

  //.....................................add new product
  async newProduct( data: Product ) {
  let newProduct =  await this.productManagerService.addProduct( data )
  .toPromise();
  return newProduct;
}

  //.....................................get list of product
  async getProductList(){
    let productList = await this.productManagerService.productList()
    .toPromise();
    this.product.push(productList); 
  }

  filtrarVacio( array: Product[] ){
    var filtered = array.filter(function (el) {
      return el != null || undefined;
    });
    
    return this.AplanarArray(filtered);
  }

  AplanarArray(arr1: Product[]) {
    return arr1.reduce((acc, val) => Array.isArray(val) ? acc.concat(this.AplanarArray(val)) : acc.concat(val), []);
 }
  
}
