import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from './components/identity-component/login/login.component';
import { RegisterComponent } from './components/identity-component/register/register.component';
import { NavbarComponent } from './components/static-pages/navbar/navbar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,LoginComponent,RegisterComponent,NavbarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'clinica';
}
