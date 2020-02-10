import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { CategoryService } from "src/app/services/category.service";

@Component({
  selector: "app-category-add-update",
  templateUrl: "./category-add-update.component.html",
  styleUrls: ["./category-add-update.component.css"]
})
export class CategoryAddUpdateComponent implements OnInit {
  myform: FormGroup;
  actionButton;
  action = null;
  myData: any;
  formData: any;

  constructor(
    public fb: FormBuilder,
    public categoryService: CategoryService
  ) {}

  ngOnInit() {
    this.actionButton = "Submit";

    // Build and Validate Reactive form
    this.myform = this.fb.group({
      name: ["", Validators.required]
      // group: this.fb.group({
      //   item1: ['', Validators.required],
      //   item2: ['', Validators.required]
      // })
    });
  }

  onFormSubmit(form1, action) {
    console.log(form1, action, "onsubmit");
    this.myData = form1;
    this.formData = Object.assign(form1);

    if (this.action === "update") {
      this.categoryService.create(this.formData);
    } else {
      this.categoryService.update(this.formData);
    }

    this.resetForm();
  }

  editForm(items, index) {
    this.actionButton = "Edit";
    this.action = "update";
    this.myform.setValue({
      name: items.name
    });
  }

  resetForm() {
    this.myform.reset();
  }
}
