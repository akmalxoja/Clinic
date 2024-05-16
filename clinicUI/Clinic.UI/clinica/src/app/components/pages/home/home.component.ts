import { Component } from '@angular/core';
import { NavbarComponent } from '../../static-pages/navbar/navbar.component';
import { FooterComponent } from '../../static-pages/footer/footer.component';
import { DurationTimeComponent } from '../../static-pages/duration-time/duration-time.component';
import { Specialists } from '../../../interfaces/specialists';
import { SpecialistsService } from '../../../services/specialists.service';
import { CardComponent } from '../../static-pages/card/card.component';
import { MiniSidebarComponent } from '../../static-pages/mini-sidebar/mini-sidebar.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NavbarComponent,FooterComponent,DurationTimeComponent,CardComponent,MiniSidebarComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
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
