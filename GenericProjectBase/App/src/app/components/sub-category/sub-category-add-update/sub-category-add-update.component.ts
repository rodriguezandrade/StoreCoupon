import { Component, OnInit } from '@angular/core';
import { SubCategoryService } from 'src/app/services/sub-category.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { SubCategory } from 'src/app/models/subcategory';

@Component({
  selector: 'app-sub-category-add-update',
  templateUrl: './sub-category-add-update.component.html',
  styleUrls: ['./sub-category-add-update.component.css']
})
export class SubCategoryAddUpdateComponent implements OnInit {
  subCategoryForm:FormGroup;
  action:string;
  subcategories:SubCategory= new SubCategory;
  constructor(private _subCategoryService:SubCategoryService, private _aroute:ActivatedRoute, private _router:Router) {
   }

  ngOnInit() {
    this._aroute.paramMap.subscribe(params=>{
    if(params.has("id")){
      this.action="edit";
      var id = params.get("id");
      this.getUser(id);
    }else{
      this.action="new";
      this.subCategoryForm = this.createForm(this.subcategories);
      
    }
  });
  }

//getUserfromDB
  getUser(id:string){
    this._subCategoryService.endpoint="subcategory/get";
        this._subCategoryService.read(id).subscribe(rest=>{
          this.subcategories = rest;
          this.subCategoryForm = this.createForm(this.subcategories);
         });
  }

  //Create ownerFromGroup
  createForm(subCategory:SubCategory){
        return new FormGroup({
            id : new FormControl(subCategory.id),
            name : new FormControl(subCategory.name),
            description : new FormControl(subCategory.description),
            categoryId : new FormControl(subCategory.categoryId),
            category : new FormControl(subCategory.category)
        });
    }

//reset form
  onResetForm(){
    this.subCategoryForm.reset();
}
  //Submit action
  submit(){
    if (this.action == 'new') {
        this._subCategoryService.endpoint="subcategory/save"
        this._subCategoryService.create(this.subCategoryForm.value).subscribe(result=>{
          console.log(result);
        });
        this.onResetForm();
        this._router.navigate(['/home/subcategory']);
    }else if (this.action == 'edit') {
        this._subCategoryService.endpoint="subcategory/update";
        this._subCategoryService.update(this.subCategoryForm.value).subscribe(result=>{
          console.log(result);
        }, error => {console.error(error)
                     alert(error)});
        this.onResetForm();
        this._router.navigate(['/home/subcategory']);
    }
}


}

