import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployerDashboardRoutingModule } from './employer-dashboard-routing.module';
import { EmployerDashboardComponent } from './employer-dashboard.component';
import { EmployerNavComponent } from './employer-nav/employer-nav.component';
import { EmployerProfileComponent } from './employer-profile/employer-profile.component';
import { CreateJobComponent } from './create-job/create-job.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    EmployerDashboardComponent,
    EmployerNavComponent,
    EmployerProfileComponent,
    CreateJobComponent,
    DashboardComponent
  ],
  imports: [
    CommonModule,
    EmployerDashboardRoutingModule,
    ReactiveFormsModule
  ]
})
export class EmployerDashboardModule { }
