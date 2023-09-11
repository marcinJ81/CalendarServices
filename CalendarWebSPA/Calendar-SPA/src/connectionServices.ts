import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConnectionServices {
  private apiUrl = 'http://localhost:5000/api/HairDresserServices';

  constructor(private http: HttpClient) { }

  getData(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  postData(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }

  getServices(): any{
    this.http.get(this.apiUrl).subscribe(response =>
    {
      return response; 
    }, error => {
      console.log(error);
    });
  }

}