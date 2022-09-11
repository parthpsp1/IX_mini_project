import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { JobsComponent } from './jobs/jobs.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserNavComponent } from './user-nav/user-nav.component';
import { UserProfileComponent } from './user-profile/user-profile.component';

@NgModule({
  declarations: [
    HomeComponent,
    JobsComponent,
    UserNavComponent,
    UserProfileComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    ReactiveFormsModule,
  ]
})
export class HomeModule { }
