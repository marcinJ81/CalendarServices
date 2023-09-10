import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Subscriber } from 'rxjs';
import { ConnectionServices } from 'src/connectionServices';
import { hairServicesDTO } from '../Model/hairServices';
import { NgForm } from '@angular/forms';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-hair-service',
  templateUrl: './hair-service.component.html',
  styleUrls: ['./hair-service.component.css']
})
export class HairServiceComponent implements OnInit {
  serivcesList: hairServicesDTO[] | undefined;
  newHairService: hairServicesDTO = new hairServicesDTO();

  constructor(private service: ConnectionServices) { }

  
  
  ngOnInit(): void {
    this.refreshList();
  }

  onSubmit(form: NgForm) {
    this.insertRecord(form);
  }

  insertRecord(form:NgForm) {
  console.log(this.newHairService.nameService);
    this.service.postData(this.newHairService).subscribe(
      res => {
        this.serivcesList?.push(res);
        form.resetForm();
        this.refreshList();
      },
      err => {
        console.log(err);
      }
    );
  }

  refreshList(): void {
    this.service.getData().subscribe((result: hairServicesDTO[]) => {
      this.serivcesList = result;
    });
  }

}
