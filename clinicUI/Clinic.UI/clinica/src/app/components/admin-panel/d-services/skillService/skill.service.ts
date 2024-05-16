import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../../environments/environment.development';
import { SkillModel } from '../../d-inters/skill-model';
import { map, Observable } from 'rxjs';
import { getModel } from '../../d-inters/get-model';
import { responseModel } from '../../../../interfaces/responce';
import { SkillPostModel } from '../../d-inters/create-model';
import { SkillUpdateModel } from '../../d-inters/update-model';
import { IndexerModel } from '../../d-inters/IndexerModel';

@Injectable({
  providedIn: 'root'
})
export class SkillService {

  apiurl = `${environment.apiUrl}Skills`
  constructor(private http: HttpClient) { }

  getAll(data:getModel) : Observable<SkillModel[]> {
    return this.http.get<SkillModel[]>(`${this.apiurl}/GetAllSkills?pageIndex=${data.pageIndex}&size=${data.size}`);
  }
  getById(data:IndexerModel): Observable<SkillModel> {
    return this.http.get<SkillModel>(`${this.apiurl}/GetSkillById/?Id=${data.id}`);
  }
  delByid(id:string) : Observable<responseModel>{
    return this.http.delete<responseModel>(`${this.apiurl}/DeleteSkill/?id=${id}`).pipe(
      map((response)=>{
        if(response.isSuccess){
          alert("Deleted");
        }
        return response;
      }));
  }

  update(data:SkillUpdateModel) : Observable<responseModel>{
    return this.http.put<responseModel>(`${this.apiurl}/UpdateSkill`, data).pipe(
      map((response)=>{
        if(response.isSuccess){
          alert("Updated");
        }
        return response;
      }));
  }

  create(data:SkillPostModel) : Observable<responseModel>{
    return this.http.post<responseModel>(`${this.apiurl}/CreateSkills`, data).pipe(
      map((response)=>{
        if(response.isSuccess){
          alert("Created");
        }
        return response;
      }));
  }
}
