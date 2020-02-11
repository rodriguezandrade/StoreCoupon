import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormControlName } from '@angular/forms'
import { Owner } from '../../../models/owner'
import { ActivatedRoute } from '@angular/router';
import { Rest } from '../../../providers/rest';

@Component({
    selector: 'app-edit-owner',
    templateUrl: './edit-owner.component.html',
    styleUrls: ['./edit-owner.component.scss']
})
/** edit-owner component*/
export class EditOwnerComponent implements OnInit {
    owner : Owner;
    form:FormGroup;
    /** edit-owner ctor */
    constructor(private aroute:ActivatedRoute,
                private rest : Rest) {
                    
                

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
        this.rest.GetById('owners/get/'+id).subscribe(result=>{
            this.owner = result;
            this.form = this.createForm(this.owner);
        });
    }



    createForm(owner:Owner){
        
        return new FormGroup({
            id : new FormControl(owner.id),
            firstName : new FormControl(owner.firstName),
            lastName : new FormControl(owner.lastName),
            address : new FormControl(owner.address),
            email : new FormControl(owner.email),
            telephone : new FormControl(owner.telephone),
            rfc : new FormControl(owner.rfc)
        });
    }
}