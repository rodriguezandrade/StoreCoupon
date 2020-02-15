import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl } from "@angular/forms";
import { CategoryService } from "src/app/services/category.service";
import { Category } from 'src/app/models/category';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: "app-category-add-update",
  templateUrl: "./category-add-update.component.html",
  styleUrls: ["./category-add-update.component.css"]
})
export class CategoryAddUpdateComponent implements OnInit {
  categoryForm:FormGroup;
  action:string;
  category:Category= new Category;
  constructor(private _categoryService:CategoryService, private _aroute:ActivatedRoute, private _router:Router) {
   }

  ngOnInit() {
    this._aroute.paramMap.subscribe(params=>{
      console.log(params.has("id"));
    if(params.has("id")){
      this.action="edit";
      var id = params.get("id");
      this.getCategory(id);
    }else{
      this.action="new";
      this.categoryForm = this.createForm(this.category);
      
    }
  });
  }

//getCategoryfromDB
  getCategory(id:string){
    this._categoryService.endpoint="categories/getById";
        this._categoryService.read(id).subscribe(rest=>{
          this.category = rest;
          this.categoryForm = this.createForm(this.category);
         });
  }

  //Create ownerFromGroup
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
    if (this.action == 'new') {
        console.log("new ", this.categoryForm.value);
        this._categoryService.endpoint="categories/save"
        this._categoryService.create(this.categoryForm.value).subscribe(result=>{
          console.log(result);
        });
        this.onResetForm();
        this._router.navigate(['/home/categories']);
    }else if (this.action == 'edit') {
        this._categoryService.endpoint="categories/update";
        this._categoryService.update(this.categoryForm.value).subscribe(result=>{
          console.log(result);
        }, error => {console.error(error)
                     alert(error)});
        this.onResetForm();
        this._router.navigate(['/home/categories']);
    }
}


}
