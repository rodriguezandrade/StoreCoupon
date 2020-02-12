import { Component, OnInit } from '@angular/core';
import { SubCategoryService } from 'src/app/services/sub-category.service';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { SubCategory } from 'src/app/models/subcategory';

@Component({
  selector: 'app-sub-category-add-update',
  templateUrl: './sub-category-add-update.component.html',
  styleUrls: ['./sub-category-add-update.component.css']
})
export class SubCategoryAddUpdateComponent implements OnInit {

  constructor(private subCategoryService: SubCategoryService, private aRoute: ActivatedRoute) { }
  subCategory: SubCategory;
  form: FormGroup;
  subCategories: any;
  ngOnInit() {
    this.aRoute.paramMap.subscribe(params => {
      if (params.has("id")) {
        this.getUser(params.get("id"));
        console.log(params.get("id"));

      } else {
        alert('Error: Usuario no existe');
      }
    });

    this.subCategoryService.listWithoutFilter().subscribe(res => {
      this.subCategories = res;
    });

  }

  getUser(id: string) {
    // this.rest.GetById('subcategories/get/' + id).subscribe(result => {
    //   this.subCategory = result;
    //   this.form = this.createForm(this.subCategory);
    //   console.log('formulario' + this.form);

    // });
  }

  createForm(subCategory: SubCategory) {
    return new FormGroup({
      id: new FormControl(subCategory.id),
      name: new FormControl(subCategory.name),
      description: new FormControl(subCategory.description),
      categoryId: new FormControl(subCategory.categoryId),
      category: new FormControl(subCategory.category)
    });
  }


//part of old form component
// onResetForm(){
//   this.subCategoryForm.reset();
// }

// submit(){
//   if (this.action == 'create') {
//      console.log(this.subCategoryForm.value);
     
//       this.rest.Post(this.subCategoryForm.value, 'subcategories/save').subscribe(result=>{
//           console.log(result);
//       }, error =>{
//           console.error(error);
          
//       });
//       this.onResetForm();
//       this.router.navigate(['/subcategories']);
//   }else if (this.action == 'edit') {
//       this.rest.Update(this.subCategoryForm.value, 'subcategories/update').subscribe(result =>{
//           alert(result.name + ' fue editado correctamente');
//       }, error => {console.error(error)
//                    alert(error)});
//       this.onResetForm();
//       this.router.navigate(['/subcategories']);
//   }
// }

// ngOnInit(): void {
//   this.rest.GetAll("categories/getCategories").subscribe(res=>{
//       console.log(res);
//       this.Categories = res;
      
//   });
// }
}
