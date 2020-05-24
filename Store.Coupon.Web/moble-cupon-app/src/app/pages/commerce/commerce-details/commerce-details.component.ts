import { Component, OnInit } from '@angular/core';
import { CommerceService } from '../../../services/commerce.service';
import { Commerce } from '../../../models/commerce';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-commerce-details',
  templateUrl: './commerce-details.component.html',
  styleUrls: ['./commerce-details.component.scss'],
})
export class CommerceDetailsComponent implements OnInit {
  commerce : Commerce;
  constructor( 
    private aroute:ActivatedRoute,
    private cs: CommerceService) { }

  ngOnInit() { this.getId(); }

  getId(){
    this.aroute.paramMap.subscribe(
      params =>{
        var id: number = parseInt( params.get("id") );
        this.getCategoryDetails( id );
      });
  }
    

  getCategoryDetails( id: number ){
    this.cs.details( id, "Stores" )
    .subscribe(data =>{
      this.commerce = data;
      console.log( this.commerce );
    });
  }


}
