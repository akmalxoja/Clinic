import { Component } from '@angular/core';
import { NavbarComponent } from '../../static-pages/navbar/navbar.component';
import { FooterComponent } from "../../static-pages/footer/footer.component";
import { MiniSidebarComponent } from "../../static-pages/mini-sidebar/mini-sidebar.component";

@Component({
    selector: 'app-contacts',
    standalone: true,
    templateUrl: './contacts.component.html',
    styleUrl: './contacts.component.scss',
    imports: [NavbarComponent, FooterComponent, MiniSidebarComponent]
})
export class ContactsComponent {

}
