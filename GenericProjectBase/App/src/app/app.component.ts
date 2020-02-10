import { Component, OnInit } from "@angular/core";
import { CategoryService } from "./services/category.service";
import { QueryOptions } from "./services/generics/queryOptions";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent implements OnInit {
  title = "App";
  constructor() {}

  ngOnInit() {}
}
