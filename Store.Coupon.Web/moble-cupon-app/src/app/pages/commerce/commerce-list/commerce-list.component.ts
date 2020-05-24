import { Component, OnInit } from '@angular/core';
import { CommerceService } from '../../../services/commerce.service';
import { Commerce } from '../../../models/commerce'
@Component({
  selector: 'app-commerce-list',
  templateUrl: './commerce-list.component.html',
  styleUrls: ['./commerce-list.component.scss'],
})
export class CommerceListComponent implements OnInit {
  commercesList : Commerce[];

  constructor( private cs: CommerceService ) { }

  ngOnInit() { this.listCommerces() }

  listCommerces(){
    this.cs.listWithoutFilter("Stores")
    .subscribe(data =>{
      this.commercesList = data;
      console.log( this.commercesList );
    });
  }

}
