import { Component } from '@angular/core';
import { NavbarComponent } from '../../static-pages/navbar/navbar.component';
import { FooterComponent } from '../../static-pages/footer/footer.component';

@Component({
  selector: 'app-feedback',
  standalone: true,

  imports: [NavbarComponent,FooterComponent],
  templateUrl: './feedback.component.html',
  styleUrl: './feedback.component.scss'
})
export class FeedbackComponent {

}
