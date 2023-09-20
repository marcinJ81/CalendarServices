import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';

import { AppComponent } from './app.component';
import { HairServiceComponent } from './hair-service/hair-service.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { AddHairServiceComponent } from './add-hair-service/add-hair-service.component';


const addRouters: Router = [{
path: '', component: AppComponent
path: 
    
}];

@NgModule({
  declarations: [
    AppComponent,
    HairServiceComponent,
    AddHairServiceComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgbModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
