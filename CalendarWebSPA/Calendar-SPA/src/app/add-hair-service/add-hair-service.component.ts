import { Component, OnInit, ViewChild } from '@angular/core';
import { hairServicesDTO } from '../Model/hairServices';
import { NgForm } from '@angular/forms';
import { ConnectionServices } from 'src/connectionServices';

@Component({
  selector: 'app-add-hair-service',
  templateUrl: './add-hair-service.component.html',
  styleUrls: ['./add-hair-service.component.css']
})
export class AddHairServiceComponent implements OnInit {
  newHairService: hairServicesDTO = new hairServicesDTO();
  @ViewChild('f') signupForm!: NgForm;
  
  constructor(private service: ConnectionServices) { }

  ngOnInit(): void {
  }
  
  onSubmit(form: NgForm) {
    this.insertRecord(form);
    console.log(this.signupForm);
  }

  insertRecord(form:NgForm) {
    console.log(this.newHairService.nameService);
      this.service.postData(this.newHairService).subscribe(
        res => {
          //this.refreshList();
        },
        err => {
          console.log(err);
        }
      );
    }

}
