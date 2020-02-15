import { Component, OnInit, SimpleChanges } from '@angular/core';
import { SubCategory } from 'src/app/models/subcategory';
import { SubCategoryService } from 'src/app/services/sub-category.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sub-category',
  templateUrl: './sub-category.component.html',
  styleUrls: ['./sub-category.component.css']
})
export class SubCategoryComponent implements OnInit {
  subcategories: SubCategory[];
  constructor(private _subCategoryService:SubCategoryService, private _router:Router) { 
    this.fillTable();
  }
  
  ngOnChanges(changes: SimpleChanges): void {
       
    this.fillTable();
}

fillTable(){
  this._subCategoryService.endpoint="subcategories/get";
  this._subCategoryService.listWithoutFilter()
  .subscribe(data =>{
    this.subcategories=data;
    console.log(data);
  });
}

onEdit(id: string) {
  this._router.navigate(['/home/subcategories',id, 'edit']);
}

onDelete(id:string){
  if (confirm("¿Esta seguro que desea eliminar este registro?")){
    this._subCategoryService.endpoint="subcategories/delete";
  this._subCategoryService.delete(id).subscribe(res=>{
    console.log(res);
  });
  } else {
    
  }
}


  ngOnInit() {

  }
  

}

