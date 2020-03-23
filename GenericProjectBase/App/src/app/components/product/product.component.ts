import { Component, OnInit, SimpleChanges,, } from "@angular/core";
import { ProductService } from "src/app/services/product.service";
import { QueryOptions } from "src/app/services/generics/query.options";
import { Product } from 'src/app/models/product';
import { Router } from '@angular/router';
import { faTrashAlt, faEdit } from '@fortawesome/free-regular-svg-icons';
import { BaseComponent } from '../BaseComponent/base.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit, BaseComponent {
  faTrashAlt = faTrashAlt;
  faEdit=faEdit; 
  products: Product[];

  constructor(
    private _productService: ProductService, 
    private _router: Router) { 
  }

  queryOptions = new QueryOptions();

  ngOnChanges(changes: SimpleChanges): void {
    this.fillTable();
  }

  fillTable() {
    this._productService.listWithoutFilter("product/get")
      .subscribe(data => {
        this.products = data;
      });
  }

  onEdit(id: string) {
    this._router.navigate(['/home/products', id, 'edit']);
  }

  onDelete(id: string) {
    if (confirm("¿Esta seguro que desea eliminar este registro?")) {
      ;

      this._productService.delete(id, "products/delete").subscribe(res => {
        console.log(res);
      });
    } else {

    }
  }
  ngOnInit() {
    this.fillTable();
  }

}
