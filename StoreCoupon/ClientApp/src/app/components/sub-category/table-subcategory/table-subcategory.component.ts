import { Component, SimpleChanges, OnInit } from '@angular/core';
import { SubCategory } from '../../../models/subcategory';
import { Rest } from '../../../providers/rest';
import { Router } from '@angular/router';

@Component({
    selector: 'app-table-subcategory',
    templateUrl: './table-subcategory.component.html',
    styleUrls: ['./table-subcategory.component.scss']
})
/** TableSubcategory component*/
export class TableSubcategoryComponent{
    subcategories:SubCategory[];
    constructor(private rest:Rest, private router:Router) {
        this.FillTable();
    }

    FillTable()  {
        this.rest.GetAll("subcategories/get").subscribe(result =>{
         this.subcategories = result;
        });
    }

    onDelete(id:string){
        this.rest.Delete("subcategories/delete/"+id).subscribe(result=>{
            console.log(result);
            this.FillTable();
        });
        
    } 

    onEdit(id:string){
        this.router.navigate(['/subcategories', id , 'edit']);
    }

    
    ngOnChanges(changes: SimpleChanges): void {
       
        this.FillTable();
    }
    ngAfterViewInit(): void {
        this.FillTable();
    } 
}