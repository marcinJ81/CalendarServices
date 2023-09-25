import { Component, OnInit } from '@angular/core';
import {  ActivatedRoute, Router } from '@angular/router';

import { ConnectionServices } from 'src/connectionServices';
import { endPointWebApi } from '../Model/endPointWebApi';
import { hairServices } from '../Model/hairServices';
import { formatMethod } from '../services/formatMethod';

@Component({
  selector: 'app-hair-service',
  templateUrl: './hair-service.component.html',
  styleUrls: ['./hair-service.component.css']
})
export class HairServiceComponent implements OnInit {
  serivcesList: hairServices[] | undefined;
  hairServiceUrl: endPointWebApi;
  visibleButton: boolean = true;

  
  constructor(private router: ActivatedRoute,
               private service: ConnectionServices,
               private route: Router,
               private formatString: formatMethod) {
    this.hairServiceUrl = new endPointWebApi();
   }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(): void {
    this.service.getData(this.hairServiceUrl.HairServiceUrl).subscribe((result: hairServices[]) => {
      this.serivcesList = result;
    });
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
