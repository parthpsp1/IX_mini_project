import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DemoComponent } from '../demo/demo.component';
import { HomeComponent } from '../home/home.component';
import { JobsComponent } from '../home/jobs/jobs.component';
import { EmployerLoginComponent } from '../landing/employer-login/employer-login.component';
import { EmployerRegistrationComponent } from '../landing/employer-registration/employer-registration.component';
import { UserLoginComponent } from '../landing/user-login/user-login.component';
import { UserRegistrationComponent } from '../landing/user-registration/user-registration.component';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { LandingComponent } from './landing.component';

const routes: Routes = [
    {
        path: '', component: LandingComponent,
        children: [
            { path: '', component: FrontpageComponent },
            { path: 'userLogin', component: UserLoginComponent },
            { path: 'userRegistration', component: UserRegistrationComponent },
            { path: 'employerLogin', component: EmployerLoginComponent },
            { path: 'employerRegistration', component: EmployerRegistrationComponent },
        ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LandingRoutingModule { }
