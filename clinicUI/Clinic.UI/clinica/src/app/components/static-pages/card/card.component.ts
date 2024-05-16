import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-card',
  standalone: true,
  imports: [
    FormsModule,
    RouterModule],
  templateUrl: './card.component.html',
  styleUrl: './card.component.scss'
})
export class CardComponent {
  @Input() picturePath:string=""
  @Input() country:string=""
  @Input() fullname:string=""
  @Input() skill:string=""
  @Input() specialst:string=""
  @Input() startWork:string=""
  @Input() description:string=""
}
