import { Component } from '@angular/core';
import { NavbarComponent } from '../../static-pages/navbar/navbar.component';
import { FooterComponent } from '../../static-pages/footer/footer.component';
import { MiniSidebarComponent } from '../../static-pages/mini-sidebar/mini-sidebar.component';
import { CardComponent } from '../../static-pages/card/card.component';
import { DurationTimeComponent } from '../../static-pages/duration-time/duration-time.component';
import { Specialist, Specialists } from '../../../interfaces/specialists';
import { SpecialistsService } from '../../../services/specialists.service';

@Component({
  selector: 'app-specialists',
  standalone: true,
  imports: [
    NavbarComponent,
    FooterComponent,
    MiniSidebarComponent,
    CardComponent,
    DurationTimeComponent],
  templateUrl: './specialists.component.html',
  styleUrl: './specialists.component.scss'
})
export class SpecialistsComponent {
  Doctors!:Specialists[]
  pageIndex:number=1
  size:number=10
  constructor(private specialistsService:SpecialistsService){
    this.getall()
  }
  getall(){
    this.specialistsService.getAllDoctors(this.pageIndex,this.size).subscribe({
      next:(data)=>{
        this.Doctors=data
        console.log(data)
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }
}
