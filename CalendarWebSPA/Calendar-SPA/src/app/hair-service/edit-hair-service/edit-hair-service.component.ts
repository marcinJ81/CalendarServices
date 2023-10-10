import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { endPointWebApi } from 'src/app/Model/endPointWebApi';
import { hairServices } from 'src/app/Model/hairServices';
import { typeService } from 'src/app/Model/typeServices';
import { formatMethod } from 'src/app/services/formatMethod';
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
  paramsSub: any;

  constructor(private route: ActivatedRoute,
              private service: ConnectionServices,
              private router: Router,
              private formatText: formatMethod) {
    this.hairServiceUrl = new endPointWebApi();
   }

  ngOnInit(): void {
    this.getData();
  }

  getData() {
      this.getTypeServices();
      this.paramsSub = this.route.params.subscribe(params => this.id = parseInt(params['id']));
      this.service.getSpecificDataFromUrl(this.hairServiceUrl.HairServiceUrl, this.id ).subscribe((result: hairServices) => {
        this.editHairService =  new hairServices();
        this.editHairService.id = result.id;
        this.editHairService.nameService = result.nameService;
        this.editHairService.price = result.price;
        this.editHairService.serviceTime = this.formatText.formatTime(result.serviceTime);
      });
  }

  getTypeServices(){
    this.service.getData(this.hairServiceUrl.TypeServiceUrl).subscribe((result: typeService[]) => {
      this.typeServiceList = result;
    });
  }

  onSubmit(form: NgForm) {
    this.updateRecord(form, this.id);
    this.refreshValue();
  }

  ngOnDestroy() {
    this.paramsSub.unsubscribe();
  }

  refreshValue() {
    this.signupForm.reset();
    //this is not good for me, not refresh list
    this.router.navigate(['/services']);
  }

  updateRecord(form:NgForm, id: number) {
    //another way
    let newService2: hairServices = {
      id: this.id,
      nameService: this.signupForm.value.nameService,
      serviceTime: this.signupForm.value.serviceTime,
      price: this.signupForm.value.price,
      typeService: this.signupForm.value.typeServiceName
    }

     this.formValue = form.value;
      this.service.putData(newService2,this.hairServiceUrl.HairServiceUrl,id).subscribe(
        res => {
         //maybe 200 return?
        },
        err => {
          console.log(err);
        }
      );
    }
  
}
