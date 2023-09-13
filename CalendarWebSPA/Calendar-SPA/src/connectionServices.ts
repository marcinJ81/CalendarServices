import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConnectionServices {

  constructor(private http: HttpClient) { }

  getData(apiUrl: string): Observable<any> {
    return this.http.get(apiUrl);
  }

  postData(data: any, apiUrl: string): Observable<any> {
    return this.http.post(apiUrl, data);
  }

  getServices(apiUrl: string): any{
    this.http.get(apiUrl).subscribe(response =>
    {
      return response; 
    }, error => {
      console.log(error);
    });
  }

}