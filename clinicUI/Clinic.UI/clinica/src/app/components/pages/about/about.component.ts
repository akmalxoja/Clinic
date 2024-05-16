import { Component } from '@angular/core';
import { NavbarComponent } from '../../static-pages/navbar/navbar.component';
import { FooterComponent } from '../../static-pages/footer/footer.component';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [NavbarComponent,FooterComponent],
  templateUrl: './about.component.html',
  styleUrl: './about.component.scss'
})
export class AboutComponent {

}
