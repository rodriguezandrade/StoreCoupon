import { Component } from '@angular/core';
import { Category } from '../../../models/category';
import { FormGroup, FormControl } from '@angular/forms';
import { Rest } from '../../../providers/rest';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-edit-category',
    templateUrl: './edit-category.component.html',
    styleUrls: ['./edit-category.component.scss']
})
/** edit-category component*/
export class EditCategoryComponent {

    category : Category;
    form:FormGroup;
    constructor(private rest:Rest, private aroute:ActivatedRoute) {

    }
    ngOnInit(){
        this.aroute.paramMap.subscribe(params =>{
            if (params.has("id")){
                this.getUser(params.get("id"));    
            }else{
                alert('Error: Usuario no existe');
            }
        });
    }
   
    getUser(id:string){
        this.rest.GetById('categories/getById?id='+id).subscribe(result=>{
            this.category = result;
            this.form = this.createForm(this.category);
        });
    }



    createForm(category:Category){
        
        return new FormGroup({
            id : new FormControl(category.id),
            Name : new FormControl(category.name)
        });
    }
}