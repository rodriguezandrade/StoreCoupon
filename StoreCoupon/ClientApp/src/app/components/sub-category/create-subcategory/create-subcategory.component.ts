import { Component } from '@angular/core';
import { FormGroup, FormControl, FormControlName } from '@angular/forms';

@Component({
    selector: 'app-create-subcategory',
    templateUrl: './create-subcategory.component.html',
    styleUrls: ['./create-subcategory.component.scss']
})
/** create-subcategory component*/
export class CreateSubcategoryComponent {
    form:FormGroup;
    constructor() {
        this.form=this.createForm();
    }

    createForm(){
        return new FormGroup({
            name : new FormControl(''),
            description : new FormControl(''),
            categoryId : new FormControl('')
        });
    }
}