import { Component, inject, NgModule } from '@angular/core';
import { Router } from '@angular/router';
import { AuthServiceService } from '../../../services/auth-service.service';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  constructor(private router : Router,private authService : AuthServiceService){}

  tokenKey = "accessToken"
  form!: FormGroup;
  fb = inject(FormBuilder);
  decodedToken: any | null;
  
  login(){
    this.authService.login(this.form.value).subscribe(
      {
        next: (response) => {
          console.log(response);

          this.decodedToken = jwtDecode(localStorage.getItem(this.tokenKey)!)
          if(this.decodedToken.role == 'Admin'){
            this.router.navigateByUrl('/home')
            console.log('salom');
            console.log(this.decodedToken.role);
          }
          else if(this.decodedToken.role == 'User'){
            console.log('student-test');
            console.log(this.decodedToken.role);
          }
          }, error: (err) => {
            alert(err.error.message)
          }
        });       
      }
      ngOnInit(): void {
        console.log("salom")
        this.form = this.fb.group({
          email: ['', [Validators.required, Validators.email]],
          password: ['', Validators.required],
        });
      }

  toRegister()
  {
    this.router.navigateByUrl('/register')
  }
}
