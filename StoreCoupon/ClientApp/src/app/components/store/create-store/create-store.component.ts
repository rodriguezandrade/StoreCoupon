import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';


@Component({
    selector: 'app-create-store',
    templateUrl: './create-store.component.html',
    styleUrls: ['./create-store.component.scss']
})
/** CreateStore component*/
export class CreateStoreComponent {
    form:FormGroup;
    constructor() {
        this.form=this.createForm();
    }

    createForm(){
        return new FormGroup({
            name : new FormControl(''),
            fiscalName : new FormControl(''),
            address : new FormControl(''),
            telephone : new FormControl(''),
            email : new FormControl(''),
            rfc : new FormControl(''),
            subCategoryId : new FormControl('')
        });
    }
}