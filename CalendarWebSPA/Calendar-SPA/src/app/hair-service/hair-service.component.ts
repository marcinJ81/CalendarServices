import { Component, OnInit } from '@angular/core';
import {  ActivatedRoute, Router } from '@angular/router';

import { ConnectionServices } from 'src/connectionServices';
import { endPointWebApi } from '../Model/endPointWebApi';
import { hairServices } from '../Model/hairServices';
import { formatMethod } from '../services/formatMethod';
import { DataService } from '../services/DataService';

@Component({
  selector: 'app-hair-service',
  templateUrl: './hair-service.component.html',
  styleUrls: ['./hair-service.component.css']
})
export class HairServiceComponent implements OnInit {
  serivcesList: hairServices[] = [];
  hairServiceUrl: endPointWebApi;
  visibleButton: boolean = true;

  
  constructor(private router: ActivatedRoute,
               private service: ConnectionServices,
               private route: Router,
               private formatString: formatMethod,
               private dataService: DataService
               ) 
   {
    this.hairServiceUrl = new endPointWebApi();
   }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(): void {
    //zamiast tego 
    this.service.getData(this.hairServiceUrl.HairServiceUrl).subscribe((result: hairServices[]) => {
      this.serivcesList = result;
    });
    this.dataService.updateServicesList(this.serivcesList);
  }

  AddServiceClick() {
    this.route.navigate(['/services', 'add']);
  }

  EditServiceClick(id: number) {
    this.visibleButton = false;
    this.route.navigate(['/services', id, 'edit']);
    //.route.navigate(['edit'], {relativeTo: this.router} ); //not working
  }

  DeleteServiceClick(id: number) {
    console.log("in the future");
  }

  formatTime(paramText: string) :string {
    return this.formatString.formatTime(paramText);
  }

}
