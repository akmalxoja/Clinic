import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from "../../static-pages/navbar/navbar.component";
import { MiniSidebarComponent } from "../../static-pages/mini-sidebar/mini-sidebar.component";
import { FooterComponent } from "../../static-pages/footer/footer.component";
import { MyServiceService } from '../../../services/my-service.service';
import { ServiceModel } from '../../../interfaces/service';

@Component({
    selector: 'app-programms',
    standalone: true,
    templateUrl: './programms.component.html',
    styleUrl: './programms.component.scss',
    imports: [NavbarComponent, MiniSidebarComponent, FooterComponent]
})
export class ProgrammsComponent implements OnInit{
    services!:ServiceModel[];
    constructor(private serv: MyServiceService) { }
    ngOnInit(): void {
        this.getAll()
    }
    getAll(){
        this.serv.getAll(1,5).subscribe((data)=>{
            this.services = data
        });
    }
}
