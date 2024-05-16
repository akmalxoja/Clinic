import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { getModel } from '../d-inters/get-model';
import { Diplom } from '../d-inters/diplom';
import { map, Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.development';
import { IndexerModel } from '../d-inters/IndexerModel';
import { responseModel } from '../../../interfaces/responce';
import { UpdateDiplom } from '../d-inters/updateDiplom';
import { CreateDiplom } from '../d-inters/createDiplom';

@Injectable({
  providedIn: 'root'
})
export class DiplomService {
  apiUrl = environment.apiUrl+'Diplom';
  constructor(private http : HttpClient) { }

  getAll(data: getModel): Observable<Diplom[]> {
    return this.http.get<Diplom[]>(`${this.apiUrl}/GetAllDiplom?pageIndex=${data.pageIndex}&size=${data.size}`)
  }

  getById(data:IndexerModel): Observable<Diplom> {
    return this.http.get<Diplom>(`${this.apiUrl}/GetDiplomById/?Id=${data.id}`);
  }

  delByid(id:string) : Observable<responseModel>{
    return this.http.delete<responseModel>(`${this.apiUrl}/DeleteDiplom?id=${id}`).pipe(
      map((response)=>{
        if(response.isSuccess){
          alert("Deleted");
        }
        return response;
      }));
  }

  update(data:UpdateDiplom) : Observable<responseModel>{
    return this.http.put<responseModel>(`${this.apiUrl}/UpdateDiplom`, data).pipe(
      map((response)=>{
        if(response.isSuccess){
          alert("Updated");
        }
        return response;
      }));
  }

  create(data:CreateDiplom) : Observable<responseModel>{
    return this.http.post<responseModel>(`${this.apiUrl}/CreateDiplom`, data).pipe(
      map((response)=>{
        if(response.isSuccess){
          alert("Created");
        }
        return response;
      }));
  }
}

