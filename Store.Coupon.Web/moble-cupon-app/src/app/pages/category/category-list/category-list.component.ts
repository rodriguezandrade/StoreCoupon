import { Component, OnInit } from '@angular/core';
import { CategoryService } from "src/app/services/category.service";
import { Category } from '../../../models/category';
@Component({  
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss'],
})
export class CategoryListComponent implements OnInit {
  categoryList : Category[];
  constructor( private cs: CategoryService) { }

  ngOnInit() { this.listCategories() }

  listCategories(){
    this.cs.listWithoutFilter("SubCategories")
    .subscribe(data =>{
      this.categoryList = data;
      console.log( this.categoryList );
    });
  }

}
