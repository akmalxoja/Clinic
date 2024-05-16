import { Component } from '@angular/core';
import { NavbarComponent } from '../../static-pages/navbar/navbar.component';
import { FooterComponent } from '../../static-pages/footer/footer.component';
import { MiniSidebarComponent } from '../../static-pages/mini-sidebar/mini-sidebar.component';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputMaskModule } from 'primeng/inputmask';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-pricing',
  standalone: true,
  imports: [
    NavbarComponent,
    InputMaskModule,
    InputGroupModule,
    InputGroupAddonModule,
    FooterComponent,
    MiniSidebarComponent,
    FormsModule,
     NavbarComponent,
  ],
  templateUrl: './pricing.component.html',
  styleUrl: './pricing.component.scss'
})
export class PricingComponent {
}
