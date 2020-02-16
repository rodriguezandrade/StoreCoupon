import { Component, OnInit, SimpleChanges } from '@angular/core';
import { SubCategoryDto } from 'src/app/models/Dto/subCategoryDto';
import { SubCategoryService } from 'src/app/services/sub-category.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sub-category',
  templateUrl: './sub-category.component.html',
  styleUrls: ['./sub-category.component.css']
})
export class SubCategoryComponent implements OnInit {
  subcategories: SubCategoryDto[];
  constructor(private _subCategoryService:SubCategoryService, private _router:Router) { 
    this.fillTable();
  }
  
  ngOnChanges(changes: SimpleChanges): void {
       
    this.fillTable();
}

fillTable(){
  this._subCategoryService.listWithoutFilter("subcategories/getAll")
  .subscribe(data =>{
    this.subcategories = data;
    console.log(data);
  });
}

onEdit(id: string) {
  this._router.navigate(['/home/subcategories',id, 'edit']);
}

onDelete(id:string){
  if (confirm("¿Esta seguro que desea eliminar este registro?")){
  this._subCategoryService.delete(id, "subcategories/delete").subscribe(res=>{
    console.log(res);
  });
  } else {
    
  }
}


  ngOnInit() {

  }
  

}

