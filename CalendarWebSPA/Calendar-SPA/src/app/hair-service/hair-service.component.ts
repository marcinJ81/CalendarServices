import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Subscriber } from 'rxjs';
import { ConnectionServices } from 'src/connectionServices';
import { hairServicesDTO } from '../Model/hairServices';

@Component({
  selector: 'app-hair-service',
  templateUrl: './hair-service.component.html',
  styleUrls: ['./hair-service.component.css']
})
export class HairServiceComponent implements OnInit {
  serivcesList: hairServicesDTO[] | undefined;

  constructor(private service: ConnectionServices) { }

  ngOnInit(): void {
    this.service.getData().subscribe((
      result: hairServicesDTO[]) => {
        this.serivcesList = result;
      });
  }

}
