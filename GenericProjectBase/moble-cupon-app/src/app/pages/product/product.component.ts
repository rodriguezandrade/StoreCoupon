import { Component, OnInit } from '@angular/core';
import { SocialSharing } from '@ionic-native/social-sharing/ngx';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss'],
})
export class ProductComponent implements OnInit {

  

  constructor( 
    private socialSharing: SocialSharing 
    ) {  }

  ngOnInit() { }

  test(){  }



  shared(){
    // Check if sharing via email is supported
    this.socialSharing.canShareViaEmail().then(() => {
      // Sharing via email is possible
      console.log( 'es posible compartir :) ' );

    }).catch(() => {
      // Sharing via email is not possible
      console.log( 'es imposible compartir :) ' );
    });

    // Share via email
    this.socialSharing.shareViaEmail('Body', 'Subject', ['recipient@example.org']).then(() => {
      // Success!
    }).catch(() => {
      // Error!
    });
  }

}
