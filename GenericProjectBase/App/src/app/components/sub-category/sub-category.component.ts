import { Component, OnInit, SimpleChanges } from '@angular/core';
import { SubCategory } from 'src/app/models/subcategory';
import { SubCategoryService } from 'src/app/services/sub-category.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sub-category',
  templateUrl: './sub-category.component.html',
  styleUrls: ['./sub-category.component.css']
})
export class SubCategoryComponent implements OnInit {

  subcategories: SubCategory[];
  constructor(private _subCategoryService: SubCategoryService, private router: Router) {
  }

  ngOnInit() {
    this.FillTable();
  }
  
  FillTable() {
    this._subCategoryService.listWithoutFilter().subscribe(result => {
      this.subcategories = result;
    });
  }

  onDelete(id: string) {
    // this.rest.Delete("subcategories/delete/" + id).subscribe(result => {
    //   console.log(result);
    //   this.FillTable();
    // });

  }

  onEdit(id: string) {
    this.router.navigate(['/subcategories', id, 'edit']);
  }

  ngOnChanges(changes: SimpleChanges): void {

    this.FillTable();
  }

}
