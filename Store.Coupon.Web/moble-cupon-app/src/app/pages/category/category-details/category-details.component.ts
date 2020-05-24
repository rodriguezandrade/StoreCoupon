import { Component, OnInit } from '@angular/core';
import { CategoryService } from "src/app/services/category.service";
import { Category } from '../../../models/category';
import { ActivatedRoute } from '@angular/router';

@Component({ 
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrls: ['./category-details.component.scss'],
})
export class CategoryDetailsComponent implements OnInit {
  category : Category;
  constructor( 
    private aroute:ActivatedRoute,
    private cs: CategoryService) { }

  ngOnInit() { this.getId(); }

  getId(){
    this.aroute.paramMap.subscribe(
      params =>{
        var id: number = parseInt( params.get("id") );
        this.getCategoryDetails( id );
      });
  }
    

  getCategoryDetails( id: number ){
    this.cs.details( id, "SubCategories" )
    .subscribe(data =>{
      this.category = data;
      console.log( this.category );
    });
  }

}
