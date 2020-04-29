import { Component, OnInit, SimpleChanges } from '@angular/core';
import { OwnerService } from 'src/app/services/owner.service';
import { QueryOptions } from 'src/app/services/generics/query.options';
import { Owner } from 'src/app/models/owner';
import { Router } from '@angular/router'; 
import { faTrashAlt, faEdit } from '@fortawesome/free-regular-svg-icons';

@Component({
  selector: 'app-owner',
  templateUrl: './owner.component.html',
  styleUrls: ['./owner.component.css']
})
export class OwnerComponent implements OnInit {
  faTrashAlt = faTrashAlt;
  faEdit=faEdit; 
  owners:Owner[];
  constructor(private _ownerService:OwnerService, private _router:Router) { 
  }
  queryOptions = new QueryOptions();
  
  ngOnChanges(changes: SimpleChanges): void {
       
    this.fillTable();
}

fillTable(){
  this._ownerService.listWithoutFilter("userDetails/owners")
  .subscribe(data =>{
    this.owners=data;
    console.log(data);
  });
}

onEdit(id: string) {
  this._router.navigate(['/home/owners',id, 'edit']);
}

onDelete(id:string){
  if (confirm("¿Esta seguro que desea eliminar este registro?")){
    this._ownerService.delete(id, "userDetails").subscribe(res=>{
    console.log(res);
  });
  } else {
    
  }
}

  ngOnInit() {
    this.fillTable();
  }
}
