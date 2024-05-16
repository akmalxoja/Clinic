import { Component } from '@angular/core';
import { NavbarComponent } from '../../static-pages/navbar/navbar.component';
import { FooterComponent } from '../../static-pages/footer/footer.component';

@Component({
  selector: 'app-services',
  standalone: true,
  imports: [NavbarComponent,FooterComponent],
  templateUrl: './services.component.html',
  styleUrl: './services.component.scss'
})
export class ServicesComponent {

}
