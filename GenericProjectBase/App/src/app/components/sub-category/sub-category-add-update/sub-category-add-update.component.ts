import { Component, OnInit } from '@angular/core';
import { SubCategoryService } from 'src/app/services/sub-category.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { SubCategory } from 'src/app/models/subcategory';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';
import { Actions } from 'src/app/utils/enums/actions';

@Component({
  selector: 'app-sub-category-add-update',
  templateUrl: './sub-category-add-update.component.html',
  styleUrls: ['./sub-category-add-update.component.css']
})
export class SubCategoryAddUpdateComponent implements OnInit {
  subCategoryForm:FormGroup;
  action:Actions;
  subcategories:SubCategory= new SubCategory;
  categories:Category[];
  constructor(private _subCategoryService:SubCategoryService, private _categoryService:CategoryService, private _aroute:ActivatedRoute, private _router:Router) {
   }

  ngOnInit() {
    this._categoryService.listWithoutFilter("categories/getAll").subscribe(res=>{
      this.categories = res;
    });
    this._aroute.paramMap.subscribe(params=>{
    if(params.has("id")){
      this.action=Actions.Edit;
      var id = params.get("id");
      this.getSubCategory(id);
    }else{
      this.action=Actions.New;
      this.subCategoryForm = this.createForm(this.subcategories);
    }
  });
  }

//getSubCategoryfromDB
  getSubCategory(id:string){
        this._subCategoryService.read(id, "subcategory/get").subscribe(rest=>{  
          this.subcategories = rest;
          this.subCategoryForm = this.createForm(this.subcategories);
          console.log(this.subCategoryForm);
         });

  }

  //Create ownerFromGroup
  createForm(subCategory:SubCategory){
        return new FormGroup({
            id : new FormControl(subCategory.id),
            name : new FormControl(subCategory.name),
            description : new FormControl(subCategory.description),
            categoryId : new FormControl(subCategory.idSubCat)
        });
    }

//reset form
  onResetForm(){
    this.subCategoryForm.reset();
}
  //Submit action
  submit(){
    if (this.action == Actions.New) {
        this._subCategoryService.create(this.subCategoryForm.value, "subcategory/save").subscribe(result=>{
          console.log(result);
        });
        this.onResetForm();
        this._router.navigate(['/home/subcategory']);
    }else if (this.action == Actions.Edit) {
        this._subCategoryService.update(this.subCategoryForm.value, "subcategory/update").subscribe(result=>{
          console.log(result);
        }, error => {console.error(error)
                     alert(error)});
        this.onResetForm();
        this._router.navigate(['/home/subcategory']);
    }
  }
}

