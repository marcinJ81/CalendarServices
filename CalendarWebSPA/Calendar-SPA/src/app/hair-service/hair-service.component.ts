import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Subscriber } from 'rxjs';
import { ConnectionServices } from 'src/connectionServices';
import { hairServicesDTO } from '../Model/hairServices';
import { NgForm } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { endPointWebApi } from '../Model/endPointWebApi';

@Component({
  selector: 'app-hair-service',
  templateUrl: './hair-service.component.html',
  styleUrls: ['./hair-service.component.css']
})
export class HairServiceComponent implements OnInit {
  serivcesList: hairServicesDTO[] | undefined;
  hairServiceUrl: endPointWebApi;
 
  constructor(private service: ConnectionServices) {
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

}
