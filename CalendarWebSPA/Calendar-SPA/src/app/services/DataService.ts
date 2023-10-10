// data.service.ts
import { Injectable } from "@angular/core";
import { BehaviorSubject } from 'rxjs';
import { hairServices } from '../Model/hairServices';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private servicesListSubject = new BehaviorSubject<hairServices[]>([]);
  servicesList$ = this.servicesListSubject.asObservable();
//read all services
  constructor() {}

  updateServicesList(newList: hairServices[]) {
    this.servicesListSubject.next(newList);
  }
}
