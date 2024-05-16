import { Component } from '@angular/core';
import { NavbarComponent } from '../../static-pages/navbar/navbar.component';
import { MiniSidebarComponent } from '../../static-pages/mini-sidebar/mini-sidebar.component';
import { CardComponent } from '../../static-pages/card/card.component';
import { SpecialistsService } from '../../../services/specialists.service';
import { Specialists } from '../../../interfaces/specialists';
import { FooterComponent } from '../../static-pages/footer/footer.component';

@Component({
  selector: 'app-press-center',
  standalone: true,
  imports: [NavbarComponent,MiniSidebarComponent,CardComponent,FooterComponent],
  templateUrl: './press-center.component.html',
  styleUrl: './press-center.component.scss'
})
export class PressCenterComponent {
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
