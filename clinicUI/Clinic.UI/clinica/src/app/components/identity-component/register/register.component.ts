import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthServiceService } from '../../../services/auth-service.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule ,ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  constructor(private router : Router,private fb: FormBuilder, private authService : AuthServiceService){}

  form!: FormGroup;
  hide = true;


  ngOnInit(): void {
    this.form = this.fb.group({
      username: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  register() {
    if (this.form.invalid) {
      return;
    }

    this.authService.register(this.form.value).subscribe({
      next: (response) => {
        console.log(response);
        this.router.navigateByUrl('/login');
      },
      error: (err) => {
        console.log(err.error.message);
        alert(err.error.message)
      }
    });
  }

  toLogin()
  {
    this.router.navigateByUrl('/login');
  }
}
