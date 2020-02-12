import { Component, OnInit } from "@angular/core";
import { CategoryService } from "src/app/services/category.service";
import { QueryOptions } from "src/app/services/generics/queryOptions";

@Component({
  selector: "app-category",
  templateUrl: "./category.component.html",
  styleUrls: ["./category.component.css"]
})
export class CategoryComponent implements OnInit {
  constructor(private _categoryService: CategoryService) {}
  queryOptions = new QueryOptions();
  
  ngOnInit() {
     // this.queryOptions.pageNumber = 1;
    // this.queryOptions.pageSize = 1; 
    // console.log(this.queryOptions, "el query");
    
    // this._categoryService
    //   .list(this.queryOptions)
    //   .subscribe(data => console.log(data));
console.log("aq");

    this._categoryService
      .listWithoutFilter()
      .subscribe(data => console.log(data));
  }
}
