import { Component, OnInit } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { DiplomService } from '../dip-service/diplom.service';
import { Diplom } from '../d-inters/diplom';
import { getModel } from '../d-inters/get-model';
import { IndexerModel } from '../d-inters/IndexerModel';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { RouterLink } from '@angular/router';
@Component({
  selector: 'app-diploms',
  standalone: true,
  imports: [ButtonModule, TableModule, DashboardComponent,RouterLink],
  templateUrl: './diploms.component.html',
  styleUrls: ['./diploms.component.scss']
})
export class DiplomsComponent implements OnInit {
  products: Diplom[] = [];
  indexer: getModel = {
    pageIndex: 1,
    size: 10
  };
  
  constructor(private productService: DiplomService) {}

  ngOnInit() {
    this.productService.getAll(this.indexer).subscribe((data) => {
      this.products = data;
    });
  }
  del(id:string)
  {
    this.productService.delByid(id).subscribe((data)=>{
      if(data.isSuccess == true)
      {
          alert("Deleted")
      }
      alert("Not successfully")
      }
    )};
  }
