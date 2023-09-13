import { Component, OnInit, ViewChild } from '@angular/core';
import { hairServicesDTO } from '../Model/hairServices';
import { NgForm } from '@angular/forms';
import { ConnectionServices } from 'src/connectionServices';
import { endPointWebApi } from '../Model/endPointWebApi';

@Component({
  selector: 'app-add-hair-service',
  templateUrl: './add-hair-service.component.html',
  styleUrls: ['./add-hair-service.component.css']
})
export class AddHairServiceComponent implements OnInit {
  newHairService: hairServicesDTO = new hairServicesDTO();
  @ViewChild('f') signupForm!: NgForm;
  defaultValue: string = "Nazwa usługi";
  answer ='';
  typeService = ['kobieta','mężczyzna','dziecko'];
  hairServiceUrl: endPointWebApi;

  constructor(private service: ConnectionServices) {
    this.hairServiceUrl = new endPointWebApi();
  }

  ngOnInit(): void {
  }
  
  onSubmit(form: NgForm) {
    this.insertRecord(form);
    console.log(this.signupForm);
  }

  insertRecord(form:NgForm) {
    console.log(this.newHairService.nameService);
      this.service.postData(form,this.hairServiceUrl.HairServiceUrl).subscribe(
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
    }

    suggestValue(){
      this.signupForm.setValue({
        serviceData: {
          nameService: 'nazwa usługi',
          price: '11'
        },
        questionAnswer: '',
        typeService: 'dziecko'
      });
    }

    getTypeServices(){

    }
}
