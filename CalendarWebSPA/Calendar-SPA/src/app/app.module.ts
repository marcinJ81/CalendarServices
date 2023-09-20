import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HairServiceComponent } from './hair-service/hair-service.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { AddHairServiceComponent } from './hair-service/add-hair-service/add-hair-service.component';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { CustomerComponent } from './customer/customer.component';
import { EditCustomerComponent } from './customer/edit-customer/edit-customer.component';
import { AddCustomerComponent } from './customer/add-customer/add-customer.component';
import { CalendarListComponent } from './calendar-list/calendar-list.component';


@NgModule({
  declarations: [
    AppComponent,
    HairServiceComponent,
    AddHairServiceComponent,
    HomeComponent,
    PageNotFoundComponent,
    CustomerComponent,
    EditCustomerComponent,
    AddCustomerComponent,
    CalendarListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgbModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
