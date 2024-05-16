import { CreateDiplom } from './../../d-inters/createDiplom';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DiplomService } from '../../dip-service/diplom.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss'
})
export class CreateComponentA {
  constructor(private service: DiplomService,private router : Router){}
  createModel : CreateDiplom =  {
    litsenzyaId: '',
    doctorId:'',
    picturePath:''
  }

  handleFileInput(event: any) {
    const file = event.target.files[0];
    this.createModel.picturePath = file;
  }

  Create() {

    this.service.create(this.createModel).subscribe(
      (data) => {
        if (data.isSuccess === true) {
          this.router.navigateByUrl('/dashboard/diplom');
        }
      },
      (error) => {
        console.error('Error creating diplom:', error);
      }
    );
  }
}
