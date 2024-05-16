import { IndexerModel } from './../../d-inters/IndexerModel';
import { SkillPostModel } from './../../d-inters/create-model';
import { FormsModule, NgModel } from '@angular/forms';
import { SkillService } from './../../d-services/skillService/skill.service';
import { Component } from '@angular/core';
import { SkillModel } from '../../d-inters/skill-model';
import { SkillUpdateModel } from '../../d-inters/update-model';

@Component({
  selector: 'app-update',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './update.component.html',
  styleUrl: './update.component.scss'
})
export class UpdateComponent {


  myid : string = '';

  indexer : IndexerModel={
    id : 'bc377502-8ca9-45d0-941b-dde8082b6a9d'
  }

  existProduct : SkillUpdateModel = {
    id : '',
    name : "",
    }

    
    constructor(private crud : SkillService) { }

    updateProduct(product: SkillUpdateModel){
      this.crud.update(product).subscribe({
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

    update(){
      if(this.existProduct.name == null || this.existProduct.name == "" )
      {
              return;
      }
      this.updateProduct(this.existProduct);
    }

    getById(){
      this.indexer.id = this.myid
      this.crud.getById(this.indexer).subscribe({next : (data)=>
        {
          this.existProduct = data;
          console.log(data);
        },
        error : (err)=>{
          console.log(err);
        },
      })
    }
    clickedById(){
      this.getById();
    }
}
