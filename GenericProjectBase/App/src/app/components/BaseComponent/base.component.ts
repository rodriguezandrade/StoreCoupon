import { Injectable, OnInit } from '@angular/core';
import { HelperService } from 'src/app/services/helper/helper.service';
 
@Injectable()
export abstract class BaseComponent implements OnInit {
 
  ngOnInit() {  
  }
}
