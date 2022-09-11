import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingComponent } from './landing.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EmployerLoginComponent } from './employer-login/employer-login.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { EmployerRegistrationComponent } from './employer-registration/employer-registration.component';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { LandingRoutingModule } from './landing-routing.module';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { HomeModule } from '../home/home.module';



@NgModule({
  declarations: [
    LandingComponent,
    EmployerLoginComponent,
    EmployerRegistrationComponent,
    UserLoginComponent,
    UserRegistrationComponent,
    NavbarComponent,
    FooterComponent,
    FrontpageComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    LandingRoutingModule,
  ]
})
export class LandingModule { }
