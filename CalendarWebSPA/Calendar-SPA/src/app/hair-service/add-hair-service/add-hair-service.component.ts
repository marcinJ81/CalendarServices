import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { hairServicesDTO } from '../../Model/hairServices';
import { NgForm } from '@angular/forms';
import { ConnectionServices } from 'src/connectionServices';
import { endPointWebApi } from '../../Model/endPointWebApi';
import { typeService } from '../../Model/typeServices';
import { Time } from '@angular/common';


@Component({
  selector: 'app-add-hair-service',
  templateUrl: './add-hair-service.component.html',
  styleUrls: ['./add-hair-service.component.css']
})
export class AddHairServiceComponent implements OnInit {
  newHairService: hairServicesDTO = new hairServicesDTO();
  @ViewChild('f') signupForm!: NgForm;
  typeServiceList: typeService[] = [];
  selectedType: string = 'Kobieta';
  hairServiceUrl: endPointWebApi;
  defaultTime: Date = new Date();
  formValue: object | undefined;

  constructor(private router: Router, private service: ConnectionServices) {
    this.hairServiceUrl = new endPointWebApi();
  }

  ngOnInit(): void {
    this.getTypeServices();
  }
  
  onSubmit(form: NgForm) {
    this.insertRecord(form);
    console.log(this.signupForm);
  }

  insertRecord(form:NgForm) {
    //one way
    let newService: hairServicesDTO = {
      nameService: form.value.serviceData.nameService,
      serviceTime: form.value.serviceTime,
      id: 0,
      price: form.value.serviceData.price,
      typeService: form.value.typeServiceName
    }
    //another way
    let newService2: hairServicesDTO = {
      nameService: this.signupForm.value.serviceData.nameService,
      serviceTime: this.signupForm.value.serviceTime,
      id: 0,
      price: this.signupForm.value.serviceData.price,
      typeService: this.signupForm.value.typeServiceName
    }

     this.formValue = form.value;
      this.service.postData(newService2,this.hairServiceUrl.HairServiceUrl).subscribe(
        res => {
          this.refreshValue();
        },
        err => {
          console.log(err);
        }
      );
    }

    refreshValue() {
      this.signupForm.reset();
      //this is not good for me, not refresh list
      this.router.navigate(['/services']);
    }

    suggestValue(){
      this.signupForm.form.patchValue({
        serviceTime: this.defaultTime.getTime()
      });
    }

    getTypeServices(){
      this.service.getData(this.hairServiceUrl.TypeServiceUrl).subscribe((result: typeService[]) => {
        this.typeServiceList = result;
      });
    }
}
