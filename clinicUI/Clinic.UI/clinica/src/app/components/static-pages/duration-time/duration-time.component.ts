import { Component,Input } from '@angular/core';

@Component({
  selector: 'app-duration-time',
  standalone: true,
  imports: [],
  templateUrl: './duration-time.component.html',
  styleUrl: './duration-time.component.scss'
})
export class DurationTimeComponent {
  @Input() beforeTime:string=""
  @Input() time:string=""
  @Input() timeDescription=""
  @Input() mainDescription=""
}
