import { Component } from '@angular/core';
import { SkillModel } from '../d-inters/skill-model';
import { SkillService } from '../d-services/skillService/skill.service';
import { getModel } from '../d-inters/get-model';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [DashboardComponent],
  templateUrl: './skills.component.html',
  styleUrl: './skills.component.scss'
})
export class SkillsComponent {

  skills!:SkillModel[]
  indexer:getModel ={
    pageIndex : 1,
    size: 10
  }

  constructor(private servise : SkillService,private router: Router){}
  ngOnInit(): void {
    this.getAllProducts();
  }

  getAllProducts(){
    this.servise.getAll(this.indexer).subscribe({
      next : (data) => {
        this.skills = data;
        console.log(data);
      },
      error: (err) => {
        console.log(err);
      }
    })}

    Delete(id:string){
      this.servise.delByid(id).subscribe(result =>
        console.log(result)
        )
    }
    Update(){
      console.log("contr")
      this.router.navigateByUrl('/dashboard/skills/update');
    }

    Create()
    {
      console.log('contr')
      this.router.navigateByUrl('/dashboard/skills/create')
    }
  
}
