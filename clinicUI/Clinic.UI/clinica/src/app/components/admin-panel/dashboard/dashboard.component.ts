import { Component } from '@angular/core';
import { RouterLink, RouterModule } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { TabMenuModule } from 'primeng/tabmenu';
@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [RouterLink,RouterModule,TabMenuModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {

  items: MenuItem[] | undefined;
    ngOnInit() {
      this.items = [
        { label: 'Dashboard', icon: 'pi pi-home', routerLink: '/dashboard/dashhome' },
        { label: 'Doctors', icon: 'pi pi-home', routerLink: '/dashboard/doctor' },
        { label: 'Services', icon: 'pi pi-home', routerLink: '/dashboard/services' },
        { label: 'Skills', icon: 'pi pi-home', routerLink: '/dashboard/skills' },
        { label: 'ServiceTypes', icon: 'pi pi-home', routerLink: '/dashboard/servtypes' },
        { label: 'Specialists', icon: 'pi pi-home', routerLink: '/dashboard/spec' },
        { label: 'Feedbacks', icon: 'pi pi-home', routerLink: '/dashboard/feedbacks' },
        { label: 'News', icon: 'pi pi-home', routerLink: '/dashboard/news' },
        { label: 'Diploms', icon: 'pi pi-home', routerLink: '/dashboard/diplom' },
        { label: 'Results', icon: 'pi pi-home', routerLink: '/dashboard/results' },
        { label: 'Educations', icon: 'pi pi-home', routerLink: '/dashboard/edu' },
        { label: 'users', icon: 'pi pi-home', routerLink: '/dashboard/users' },
      ];
    }
}
