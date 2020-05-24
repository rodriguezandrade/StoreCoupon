import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

//componentes
import { ControlMessagesComponent } from './validator/control-messages/control-messages.component';

//services
import { ValidationService } from './validator/validation.service';

@NgModule({
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule
  ],
  exports: [
    ControlMessagesComponent
  ],
  declarations: [
    ControlMessagesComponent
  ],
  providers: [
    ValidationService
  ]
})
export class CommonsWebPageModule {}
