import { Component } from '@angular/core';
import { SkillPostModel } from '../../d-inters/create-model';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { SkillService } from '../../d-services/skillService/skill.service';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss'
})
export class CreateComponent {
  creatModel : SkillPostModel = {
    name: ''
  };
  
  constructor(private service: SkillService) { }

  create()
  {
  this.service.create(this.creatModel).subscribe({
    next : (data) => {
      if(data.isSuccess == true)
      {
        alert("Successfully")
      }
      console.log(data);
    },
    error : (err) => {
      console.log(err);
      alert("UnSuccessfully")
    }
  })
  }
}
