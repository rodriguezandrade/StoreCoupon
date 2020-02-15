import { Component, OnInit, SimpleChanges } from "@angular/core";
import { CategoryService } from "src/app/services/category.service";
import { QueryOptions } from "src/app/services/generics/query.options";
import { Category } from 'src/app/models/category';
import { Router } from '@angular/router';

@Component({
  selector: "app-category",
  templateUrl: "./category.component.html",
  styleUrls: ["./category.component.css"]
})
export class CategoryComponent implements OnInit {
  categories:Category[];
  constructor(private _categoryService: CategoryService, private _router:Router) { 
    this.fillTable();
  }
  queryOptions = new QueryOptions();
  
  ngOnChanges(changes: SimpleChanges): void {
       
    this.fillTable();
}


fillTable(){
  this._categoryService.endpoint="categories/getAll";
  this._categoryService.listWithoutFilter()
  .subscribe(data =>{
    this.categories=data;
  });
}

onEdit(id: string) {
  this._router.navigate(['/home/categories',id, 'edit']);
}

onDelete(id:string){
  if (confirm("¿Esta seguro que desea eliminar este registro?")){
    this._categoryService.endpoint="categories/delete";
  this._categoryService.delete(id).subscribe(res=>{
    console.log(res);
  });
  } else {
    
  }
}


  ngOnInit() {

  }
  

}
