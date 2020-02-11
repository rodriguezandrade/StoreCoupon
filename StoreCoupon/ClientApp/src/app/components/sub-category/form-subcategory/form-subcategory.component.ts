import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Rest } from '../../../providers/rest';
import { Router } from '@angular/router';

@Component({
    selector: 'app-form-subcategory',
    templateUrl: './form-subcategory.component.html',
    styleUrls: ['./form-subcategory.component.scss']
})
/** formSubcategory component*/
export class FormSubcategoryComponent {
    @Input() action:string;
    @Input() subCategoryForm : FormGroup;
    Categories:[]=[];
    constructor(private rest:Rest, private router:Router) {
      
    }
    onResetForm(){
        this.subCategoryForm.reset();
    }

    submit(){
        if (this.action == 'create') {
           console.log(this.subCategoryForm.value);
           
            this.rest.Post(this.subCategoryForm.value, 'subcategories/save').subscribe(result=>{
                console.log(result);
            }, error =>{
                console.error(error);
                
            });
            this.onResetForm();
            this.router.navigate(['/subcategories']);
        }else if (this.action == 'edit') {
            this.rest.Update(this.subCategoryForm.value, 'subcategories/update').subscribe(result =>{
                alert(result.name + ' fue editado correctamente');
            }, error => {console.error(error)
                         alert(error)});
            this.onResetForm();
            this.router.navigate(['/subcategories']);
        }
    }

    ngOnInit(): void {
        this.rest.GetAll("categories/getCategories").subscribe(res=>{
            console.log(res);
            this.Categories = res;
            
        });
    }

   
}