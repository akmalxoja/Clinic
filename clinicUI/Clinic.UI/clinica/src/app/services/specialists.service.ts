import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Specialist, Specialists } from '../interfaces/specialists';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SpecialistsService {

  apiUrl = environment.apiUrl
  constructor(private httpClient: HttpClient) { }

  getAllDoctors(pageIndex: number, size: number): Observable<Specialists[]> {
    return this.httpClient.get<Specialists[]>(this.apiUrl + `Doctor/GetAllDoctor?pageIndex=${pageIndex}&size=${size}`)
  }

  getPictureByPath(path:string):Observable<any>{
    return this.httpClient.get<any>(this.apiUrl+`SendPicture?path=${path}`)
  }
}
