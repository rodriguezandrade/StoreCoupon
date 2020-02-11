import { Component, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms'
import { Rest } from '../../../providers/rest';
import { Router } from '@angular/router';

@Component({
    selector: 'app-form-owner',
    templateUrl: './form-owner.component.html',
    styleUrls: ['./form-owner.component.scss']
})
/** form-owner component*/
export class FormOwnerComponent {
    @Input() action:string;
   @Input() ownerForm : FormGroup;
    
    constructor(private rest:Rest, private router:Router) {
      
    }
    onResetForm(){
        this.ownerForm.reset();
    }

    submit(){
        if (this.action == 'create') {
            console.log(this.ownerForm.value);
            this.rest.Post(this.ownerForm.value, 'owners/save').subscribe(result=>{
                console.log(result);
            }, error =>{
                console.error(error);
                
            });
            this.onResetForm();
            this.router.navigate(['/owners']);
        }else if (this.action == 'edit') {
            this.rest.Update(this.ownerForm.value, 'owners/update').subscribe(result =>{
                alert(result.firstName + 'fue editado correctamente');
            }, error => {console.error(error)
                         alert(error)});
            this.onResetForm();
            this.router.navigate(['/owners']);
        }
    }

   
}