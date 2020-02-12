import { Component } from '@angular/core';
import {SubCategory} from '../../../models/subcategory';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Rest } from '../../../providers/rest';
import { from } from 'rxjs';

@Component({
    selector: 'app-edit-subcategory',
    templateUrl: './edit-subcategory.component.html',
    styleUrls: ['./edit-subcategory.component.scss']
})
/** editSubcategory component*/
export class EditSubcategoryComponent {
    subCategory : SubCategory;
    form:FormGroup;
    categories:[]=[];
    constructor(private aroute:ActivatedRoute,
                private rest : Rest) {
                    
                

    }

    ngOnInit(){
        this.aroute.paramMap.subscribe(params =>{
            if (params.has("id")){
                this.getUser(params.get("id"));
                console.log(params.get("id"));
                    
            }else{
                alert('Error: Usuario no existe');
            }
        });
        this.rest.GetAll('categories/getCategories').subscribe(res => {
            this.categories=res;
        });
    
    }
   
    getUser(id:string){
        this.rest.GetById('subcategories/get/'+id).subscribe(result=>{
            this.subCategory = result;
            this.form = this.createForm(this.subCategory);
            console.log('formulario'+ this.form);
            
        });
    }



    createForm(subCategory:SubCategory){
        
        return new FormGroup({
            id : new FormControl(subCategory.id),
            name : new FormControl(subCategory.name),
            description : new FormControl(subCategory.description),
            categoryId : new FormControl(subCategory.categoryId),
            category : new FormControl(subCategory.category)
        });
    }
   
}