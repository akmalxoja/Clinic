import { Routes } from '@angular/router';
import { LoginComponent } from './components/identity-component/login/login.component';
import { RegisterComponent } from './components/identity-component/register/register.component';
import { HomeComponent } from './components/pages/home/home.component';
import { CreateComponentA } from './components/admin-panel/diploms/create/create.component';
import { NotFoundComponent } from './components/pages/not-found/not-found.component';
import { DoctorComponent } from './components/pages/doctor/doctor.component';
import { adminGuard,clinicGuard,expireGuard } from './guards/clinic.guard';
import { DashboardComponent } from './components/admin-panel/dashboard/dashboard.component';
import { SpecialistsComponent } from './components/pages/specialists/specialists.component';
import { SkillsComponent } from './components/admin-panel/skills/skills.component';
import { ServicesComponent } from './components/pages/services/services.component';
import { PricingComponent } from './components/pages/pricing/pricing.component';
import { FeedbackComponent } from './components/pages/feedback/feedback.component';
import { AboutComponent } from './components/pages/about/about.component';
import { UpdateComponent } from './components/admin-panel/skills/update/update.component';
import { HomeDashComponent } from './components/admin-panel/home-dash/home-dash.component';
import { ProgrammaComponent } from './components/pages/programma/programma.component';

import { CreateComponent } from './components/admin-panel/skills/create/create.component';
import { DiplomsComponent } from './components/admin-panel/diploms/diploms.component';
import { ContactsComponent } from './components/pages/contacts/contacts.component';
import { ServiceComponent } from './components/pages/service/service.component';
import { PressCenterComponent } from './components/pages/press-center/press-center.component';
import { ProgrammsComponent } from './components/pages/programms/programms.component';

export const routes: Routes = [
    {path : 'login', component : LoginComponent},
    {path: 'register', component : RegisterComponent},

    {path: 'home',component:HomeComponent},
    {path: 'doctor', component: DoctorComponent},
    {path: 'program', component: ProgrammsComponent},
    {path: 'programma', component: ProgrammaComponent},
    {path: 'dashboard',component: HomeDashComponent},
    {path: 'service', component:ServiceComponent},
    {path: 'services',component:ServicesComponent},
    {path:'pricing',component:PricingComponent},
    {path:'feedback',component:FeedbackComponent},
    {path:'contact',component:ContactsComponent,canActivate:[clinicGuard,expireGuard]},
    {path:'about',component:AboutComponent},
    {path: 'dashboard',
        children: [
            {path: 'skills', component:SkillsComponent},
            {path: 'dashhome', component:HomeDashComponent},
            {path : 'skills', children:[
                {path: 'update',component: UpdateComponent},
                {path: 'create',component: CreateComponent}
            ]},
            {path:'diplom',component:DiplomsComponent},
            {path:'diplom',children:[
                {path: 'create',component:CreateComponentA}
            ]}
        ]},
    {path: 'specialists',component:SpecialistsComponent,canActivate:[clinicGuard,expireGuard]},
    {path:"press-center",component:PressCenterComponent},
    {path:'',component:HomeComponent,canActivate:[clinicGuard,expireGuard]},
    {path:'not-found',component:NotFoundComponent},
    {path:'**',component:NotFoundComponent}
];
