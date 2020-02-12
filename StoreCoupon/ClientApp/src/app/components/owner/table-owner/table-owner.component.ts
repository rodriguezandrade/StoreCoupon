import { Component, Input, Output, SimpleChanges, OnInit } from '@angular/core';
import { Rest } from '../../../providers/rest';
import { Owner } from '../../../models/owner';
import { Router } from '@angular/router';

@Component({
    selector: 'app-table-owner',
    templateUrl: './table-owner.component.html',
    styleUrls: ['./table-owner.component.scss']
})
/** table-owner component*/
export class TableOwnerComponent{
    owners:Owner[];
    constructor(private rest:Rest, private router:Router) {
        this.FillTable();
    }

    FillTable()  {
        this.rest.GetAll("owners/get").subscribe(result =>{
         this.owners = result;
         
        });
    }

    onDelete(id:string){
        this.rest.Delete("owners/delete/"+id).subscribe(result=>{
            console.log(result);
            this.FillTable();
        });
        
    }

    onEdit(id:string){
        this.router.navigate(['/owners', id , 'edit']);
    }

    
    ngOnChanges(changes: SimpleChanges): void {
       
        this.FillTable();
    }
    ngAfterViewInit(): void {
        this.FillTable();
    }
    
   
}
