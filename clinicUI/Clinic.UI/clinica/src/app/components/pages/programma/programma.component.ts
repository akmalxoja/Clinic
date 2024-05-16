import { Component } from '@angular/core';
import { NavbarComponent } from "../../static-pages/navbar/navbar.component";
import { FooterComponent } from "../../static-pages/footer/footer.component";

@Component({
    selector: 'app-programma',
    standalone: true,
    templateUrl: './programma.component.html',
    styleUrl: './programma.component.scss',
    imports: [NavbarComponent, FooterComponent]
})
export class ProgrammaComponent {

}
