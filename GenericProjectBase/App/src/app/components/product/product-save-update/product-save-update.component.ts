import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl } from "@angular/forms";
import { CategoryService } from "src/app/services/category.service";
import { Category } from 'src/app/models/category';
import { ActivatedRoute, Router } from '@angular/router';
import { Actions } from 'src/app/utils/guards/enums/actions';

@Component({
  selector: 'app-product-save-update',
  templateUrl: './product-save-update.component.html',
  styleUrls: ['./product-save-update.component.css']
})
export class ProductSaveUpdateComponent implements OnInit {

  categoryForm:FormGroup;
  action:Actions;
  category:Category= new Category;
  constructor(private _categoryService:CategoryService, private _aroute:ActivatedRoute, private _router:Router) {
   }

  ngOnInit() {
    this._aroute.paramMap.subscribe(params=>{
      console.log(params.has("id"));
    if(params.has("id")){
      this.action=Actions.Edit;
      var id = params.get("id");
      this.getCategory(id);
    }else{
      this.action=Actions.New;
      this.categoryForm = this.createForm(this.category);
      
    }
  });
  }

//getCategoryfromDB
  getCategory(id:string){
        this._categoryService.read(id, "categories/getById").subscribe(rest=>{
          this.category = rest;
          this.categoryForm = this.createForm(this.category);
         });
  }

  //Create FromGroup
  createForm(category:Category){
    return new FormGroup({
      id : new FormControl(category.id),
      name : new FormControl(category.name)
    });
  }

//reset form
  onResetForm(){
    this.categoryForm.reset();
}
  //Submit action
  submit(){
    if (this.action == Actions.New) {
        console.log("new ", this.categoryForm.value);
        this._categoryService.create(this.categoryForm.value, "categories/save").subscribe(result=>{
        });
        this.onResetForm();
        this._router.navigate(['/home/categories']);
    }else if (this.action == Actions.Edit) {
        this._categoryService.update(this.categoryForm.value, "categories/update").subscribe(result=>{
        }, error => {console.error(error)
                     alert(error)});
        this.onResetForm();
        this._router.navigate(['/home/categories']);
    }
}


}
