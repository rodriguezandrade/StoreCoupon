import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { OwnerService } from 'src/app/services/owner.service';
import { Owner } from 'src/app/models/owner';
import { Actions } from 'src/app/enums/actions';

@Component({
  selector: 'app-owner-add-update',
  templateUrl: './owner-add-update.component.html',
  styleUrls: ['./owner-add-update.component.css']
})
export class OwnerAddUpdateComponent implements OnInit {
  ownerForm:FormGroup;
  action:number;
  owner:Owner= new Owner;
  constructor(private _ownerService:OwnerService, private _aroute:ActivatedRoute, private _router:Router) {
   }

  ngOnInit() {
    this._aroute.paramMap.subscribe(params=>{
    if(params.has("id")){
      this.action=Actions.Edit;
      console.log(this.action);
      
      var id = params.get("id");
      this.getData(id);
    }else{
      this.action=Actions.New;

      this.ownerForm = this.createForm(this.owner);
      
    }
  });
  }

//getDatafromDB
  getData(id:string){
        this._ownerService.read(id,"owners/get").subscribe(rest=>{
          this.owner = rest;
          this.ownerForm = this.createForm(this.owner);
         });
  }

  //Create FromGroup
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

//reset form
  onResetForm(){
    this.ownerForm.reset();
}
  //Submit action
  submit(){
    if (this.action == Actions.New) {
        this._ownerService.create(this.ownerForm.value, "owners/save").subscribe(result=>{
          console.log(result);
        });
        this.onResetForm();
        this._router.navigate(['/home/owners']);
    }else if (this.action == Actions.Edit) {
        this._ownerService.update(this.ownerForm.value,"owners/update").subscribe(result=>{
          console.log(result);
        }, error => {console.error(error)
                     alert(error)});
        this.onResetForm();
        this._router.navigate(['/home/owners']);
    }
  }
}
