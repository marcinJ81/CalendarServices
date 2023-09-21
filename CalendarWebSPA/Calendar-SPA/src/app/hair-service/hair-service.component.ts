import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Route, Router } from '@angular/router';

import { Subscriber } from 'rxjs';
import { ConnectionServices } from 'src/connectionServices';
import { NgForm } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { endPointWebApi } from '../Model/endPointWebApi';
import { hairServicesDTO } from '../Model/hairServices';


@Component({
  selector: 'app-hair-service',
  templateUrl: './hair-service.component.html',
  styleUrls: ['./hair-service.component.css']
})
export class HairServiceComponent implements OnInit {
  serivcesList: hairServicesDTO[] | undefined;
  hairServiceUrl: endPointWebApi;
  
 
  constructor(private router: Router, private service: ConnectionServices) {
    this.hairServiceUrl = new endPointWebApi();
   }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(): void {
    this.service.getData(this.hairServiceUrl.HairServiceUrl).subscribe((result: hairServicesDTO[]) => {
      this.serivcesList = result;
    });
  }

  AddServiceClick() {
    this.router.navigate(['/services', 'add']);
  }

  EditServiceClick(id: number) {

  }

  DeleteServiceClick(id: number) {
    console.log("in the future");
  }

}
