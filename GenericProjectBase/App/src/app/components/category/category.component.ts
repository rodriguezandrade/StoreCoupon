import { Component, OnInit, SimpleChanges } from "@angular/core";
import { CategoryService } from "src/app/services/category.service";
import { QueryOptions } from "src/app/services/generics/query.options";
import { Category } from 'src/app/models/category';
import { faTrashAlt, faEdit } from '@fortawesome/free-regular-svg-icons';
import { Router } from '@angular/router';
import { Actions } from 'src/app/utils/enums/actions';

@Component({
  selector: "app-category",
  templateUrl: "./category.component.html",
  styleUrls: ["./category.component.css"]
})
export class CategoryComponent implements OnInit {
  faTrashAlt = faTrashAlt;
  faEdit=faEdit;
  action:Actions;
  categories:Category[];
  constructor(private _categoryService: CategoryService, private _router:Router) { 
  }
  queryOptions = new QueryOptions();
  
  ngOnChanges(changes: SimpleChanges): void {
    this.fillTable();
}


fillTable(){
  this._categoryService.listWithoutFilter("categories/getAll")
  .subscribe(data =>{
    this.categories=data;
  });
}

onEdit(id: string) {
  this._router.navigate(['/home/categories',id, 'edit']);
}

onDelete(id:string){
  if (confirm("¿Esta seguro que desea eliminar este registro?")){;
  this._categoryService.delete(id,"categories/delete").subscribe(res=>{
    console.log(res);
  });
  } else {
    
  }
}


  ngOnInit() {
    this.fillTable();
  }
  
}
