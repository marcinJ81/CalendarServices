import { Component, OnInit } from '@angular/core';
import {  Router } from '@angular/router';

import { ConnectionServices } from 'src/connectionServices';
import { endPointWebApi } from '../Model/endPointWebApi';
import { hairServices } from '../Model/hairServices';

@Component({
  selector: 'app-hair-service',
  templateUrl: './hair-service.component.html',
  styleUrls: ['./hair-service.component.css']
})
export class HairServiceComponent implements OnInit {
  serivcesList: hairServices[] | undefined;
  hairServiceUrl: endPointWebApi;
  visibleButton: boolean = true;

  
  constructor(private router: Router, private service: ConnectionServices) {
    this.hairServiceUrl = new endPointWebApi();
   }

  ngOnInit(): void {
    //this.visibleButton = true;
    //???
    this.refreshList();
  }

  refreshList(): void {
    this.service.getData(this.hairServiceUrl.HairServiceUrl).subscribe((result: hairServices[]) => {
      this.serivcesList = result;
    });
  }

  AddServiceClick() {
    this.router.navigate(['/services', 'add']);
  }

  EditServiceClick(id: number) {
    this.visibleButton = false;
    this.router.navigate(['/services', id, 'edit'], {queryParams: {allowEdit: id}});
    //this.router.navigate(['edit'], {queryParams: {allowEdit: id}}, {relativeTo: this.router}, );
  }

  DeleteServiceClick(id: number) {
    console.log("in the future");
  }

}
