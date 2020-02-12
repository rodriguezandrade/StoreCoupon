import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms'

@Component({
    selector: 'app-create-category',
    templateUrl: './create-category.component.html',
    styleUrls: ['./create-category.component.scss']
})
/** create-category component*/
export class CreateCategoryComponent {
    form:FormGroup;
    constructor() {
        this.form=this.createForm();
    }

    createForm(){
        return new FormGroup({
            Name : new FormControl('')
        });
    }
}