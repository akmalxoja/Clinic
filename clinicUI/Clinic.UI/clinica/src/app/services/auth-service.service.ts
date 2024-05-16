import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { tokenModel } from '../interfaces/tokenModel';
import { registerModel } from '../interfaces/register';
import { environment } from '../../environments/environment.development';
import { loginModel } from '../interfaces/login';
import { responseModel } from '../interfaces/responce';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  apiUrl = environment.apiUrl;
  constructor(private http : HttpClient,private router : Router) { }
  tokenKey = "accessToken"

  
  register(data:registerModel) : Observable<responseModel>{
    return this.http.post<responseModel>(`${this.apiUrl}Auth/Register`, data).pipe(
      map((response)=>{
        console.log(response)
        if(response.isSuccess == true){
          console.log("Registered");
        }
        this.router.navigateByUrl('/register')
        return response;
      })
    );
  }

  login(data:loginModel) : Observable<tokenModel>
  {
    console.log("salom")
    return this.http.post<tokenModel>(`${this.apiUrl}Auth/Login`, data).pipe(
      map((response)=>{
        if(response.isSuccess){
          //localStorage.clear();
          localStorage.setItem(this.tokenKey, response.token)
        }
        this.router.navigateByUrl('/home');
        return response;
      })
    );
  }

  logOut(){
    localStorage.removeItem(this.tokenKey);
  }

  isAuthorized(){
    var result = localStorage.getItem(this.tokenKey);
    if(result == null || result == "" || result == undefined)
    {
      return false;
    }
    return true;
  }

}
