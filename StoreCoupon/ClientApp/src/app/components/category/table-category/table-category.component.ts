import { Component, OnInit, SimpleChanges } from '@angular/core';
import {Category} from '../../../models/category';
import { Rest } from '../../../providers/rest';
import { Router } from '@angular/router';
@Component({
    selector: 'app-table-category',
    templateUrl: './table-category.component.html',
    styleUrls: ['./table-category.component.scss']
})
/** table-category component*/
export class TableCategoryComponent{
    categories:Category[];
    constructor(private rest:Rest, private router:Router) {
        this.FillTable();
    }

    FillTable()  {
        this.rest.GetAll("categories/getAll").subscribe(result =>{
         this.categories = result; 
        });
    }

    onDelete(id:string){
        this.rest.Delete("categories/delete?Id="+id).subscribe(result=>{
            console.log(result);
            this.FillTable();
        });
        
    }

    onEdit(id:string){
        this.router.navigate(['/categories', id , 'edit']);
    }

   
    ngOnChanges(changes: SimpleChanges): void {
       
        this.FillTable();
    }
    ngAfterViewInit(): void {
        this.FillTable();
    }
    
}
