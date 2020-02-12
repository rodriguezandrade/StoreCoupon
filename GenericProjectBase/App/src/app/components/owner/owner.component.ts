import { Component, OnInit } from '@angular/core';
import { OwnerService } from 'src/app/services/owner.service';
import { QueryOptions } from 'src/app/services/generics/queryOptions';
import { Owner } from 'src/app/models/owner';

@Component({
  selector: 'app-owner',
  templateUrl: './owner.component.html',
  styleUrls: ['./owner.component.css']
})
export class OwnerComponent implements OnInit {
  owners:Owner[];
  constructor(private _ownerService:OwnerService) { 
    this.fillTable();
  }
  queryOptions = new QueryOptions();
  
fillTable(){
  this._ownerService.listWithoutFilter()
  .subscribe(data =>{
    this.owners=data;
    console.log(data);
  });
}

  ngOnInit() {

  }
  

}
