import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HairServiceComponent } from './hair-service/hair-service.component';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { AddHairServiceComponent } from './hair-service/add-hair-service/add-hair-service.component';
import { CustomerComponent } from './customer/customer.component';
import { AddCustomerComponent } from './customer/add-customer/add-customer.component';
import { EditCustomerComponent } from './customer/edit-customer/edit-customer.component';
import { CalendarListComponent } from './calendar-list/calendar-list.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    { path: 'services', component: HairServiceComponent, children: [
        {path: 'addservice', component: AddHairServiceComponent}
    ]},
    { path: 'customers', component: CustomerComponent, children: [
        {path: 'addcustomer', component: AddCustomerComponent},
        {path: ':id/edit', component: EditCustomerComponent}
    ]},
    { path: 'calendar', component: CalendarListComponent},
    { path: 'not-found', component: PageNotFoundComponent },
    { path: '**', redirectTo: '/not-found'}
];
@NgModule ({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [RouterModule]
})
export class AppRoutingModule{

}