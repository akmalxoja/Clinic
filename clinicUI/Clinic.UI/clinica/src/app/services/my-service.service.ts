import { registerModel } from './../interfaces/register';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { ServiceModel } from '../interfaces/service';

@Injectable({
  providedIn: 'root'
})
export class MyServiceService {

  apiUrl = environment.apiUrl
  constructor(private http: HttpClient) { }

  getAll(index: number, size: number): Observable<ServiceModel[]> {
    return this.http.get<ServiceModel[]>(`${this.apiUrl}Service/GetAllServices?pageIndex=${index}&size=${size}`);
  }
}
