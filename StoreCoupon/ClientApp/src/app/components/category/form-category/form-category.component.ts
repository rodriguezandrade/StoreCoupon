import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Rest } from '../../../providers/rest';
import { Router } from '@angular/router';

@Component({
    selector: 'app-form-category',
    templateUrl: './form-category.component.html',
    styleUrls: ['./form-category.component.scss']
})
/** form-category component*/
export class FormCategoryComponent {
    @Input() action:string;
    @Input() categoryForm : FormGroup;
    constructor(private rest : Rest, private router:Router) {

    }
    onResetForm(){
        this.categoryForm.reset();
    }

    submit(){
        if (this.action == 'create') {
            console.log(this.categoryForm.value);
            this.rest.Post(this.categoryForm.value, 'categories/save').subscribe(result=>{
                console.log(result);
            }, error =>{
                console.error(error);
            });
            this.onResetForm();
            this.router.navigate(['/categories']);
        }else if (this.action == 'edit') {
            this.rest.Update(this.categoryForm.value, 'categories/update').subscribe(result =>{
                alert(result.firstName + ' fue editado correctamente');
            }, error => {console.error(error)
                         alert(error)});
            this.onResetForm();
            this.router.navigate(['/categories']);
        }
    }

   
}