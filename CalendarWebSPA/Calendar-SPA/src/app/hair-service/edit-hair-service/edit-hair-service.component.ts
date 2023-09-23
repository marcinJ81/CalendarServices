import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { endPointWebApi } from 'src/app/Model/endPointWebApi';
import { hairServices } from 'src/app/Model/hairServices';
import { typeService } from 'src/app/Model/typeServices';
import { ConnectionServices } from 'src/connectionServices';

@Component({
  selector: 'app-edit-hair-service',
  templateUrl: './edit-hair-service.component.html',
  styleUrls: ['./edit-hair-service.component.css']
})
export class EditHairServiceComponent implements OnInit {
  editHairService: hairServices = new hairServices();
  @ViewChild('f') signupForm!: NgForm;
  hairServiceUrl: endPointWebApi;
  id: number = -1;
  typeServiceList: typeService[] = [];
  formValue: object | undefined;

  constructor(private route: ActivatedRoute, private service: ConnectionServices) {
    this.hairServiceUrl = new endPointWebApi();
   }

  ngOnInit(): void {
    this.getData();
    if (this.editHairService.id > 0)
    {
      this.suggestValue();
    }
  }

  getData() {
    this.route.queryParams.subscribe(
      (queryParams: Params) => {
      this.id = +queryParams['allowEdit'];
    });
    this.service.getSpecificDataFromUrl(this.hairServiceUrl.HairServiceUrl, this.id ).subscribe((result: hairServices) => {
      this.editHairService = result;
      this.suggestValue();
    });
  }

  onSubmit(form: NgForm) {
    //put data
  }

  suggestValue(){
    this.signupForm.form.patchValue({
      nameService: this.editHairService.nameService
    });
  }


}
