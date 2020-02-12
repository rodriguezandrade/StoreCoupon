import { Component } from '@angular/core';
import { FormGroup, FormControl, FormControlName } from '@angular/forms';

@Component({
    selector: 'app-create-owner',
    templateUrl: './create-owner.component.html',
    styleUrls: ['./create-owner.component.scss']
})
/** create-owner component*/
export class CreateOwnerComponent {
    form:FormGroup;
    constructor() {
        this.form=this.createForm();
    }

    createForm(){
        return new FormGroup({
            firstName : new FormControl(''),
            lastName : new FormControl(''),
            address : new FormControl(''),
            email : new FormControl(''),
            telephone : new FormControl(),
            rfc : new FormControl('')
        });
    }
}