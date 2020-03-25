import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl } from "@angular/forms";
import { ProductService } from "src/app/services/product.service";
import { Product } from 'src/app/models/product';
import { ActivatedRoute, Router } from '@angular/router'; 
import { Actions } from 'src/app/utils/enums/actions';

@Component({
  selector: 'app-product-save-update',
  templateUrl: './product-save-update.component.html',
  styleUrls: ['./product-save-update.component.css']
})
export class ProductSaveUpdateComponent implements OnInit {

  productForm:FormGroup;
  action:Actions;
  product:Product= new Product;
  constructor(private _productService:ProductService, private _aroute:ActivatedRoute, private _router:Router) {
   }

  ngOnInit() {
    this.catchId();
  }

  catchId(){
    console.log( 'catch id run ' );
    this._aroute.paramMap.subscribe(params=>{
      console.log( params, 'parmas');
    if(params.has("id")){
      this.action=Actions.Edit;
      var id = params.get("id");
     this.getProduct(id);
    }else{
      this.action=Actions.New;
      this.productForm = this.createForm(this.product);
      
    }
  });
  }
//getCategoryfromDB
  getProduct(id:string){
        this._productService.read(id, "products/get").subscribe(rest=>{
          this.product = rest;
          this.productForm = this.createForm(this.product);
         });
  }

  //Create FromGroup
  createForm(product:Product){
    return new FormGroup({
      id : new FormControl(product.id),
      name : new FormControl(product.name),
      description: new FormControl(product.description),
      price: new FormControl(product.price)
    });
  }

//reset form
  onResetForm(){
    this.productForm.reset();
}
  //Submit action
  submit(){
    if (this.action == Actions.New) {
        console.log("new ", this.productForm.value);
        this._productService.create(this.productForm.value, "products/save").subscribe(result=>{
        });
        this.onResetForm();
        this._router.navigate(['/home/products']);
    }else if (this.action == Actions.Edit) {
        this._productService.update(this.productForm.value, "products/update").subscribe(result=>{
        }, error => {console.error(error)
                     alert(error)});
        this.onResetForm();
        this._router.navigate(['/home/products']);
    }
}


}
