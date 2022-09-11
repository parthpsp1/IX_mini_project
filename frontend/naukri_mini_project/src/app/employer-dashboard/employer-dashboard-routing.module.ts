import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateJobComponent } from './create-job/create-job.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EmployerDashboardComponent } from './employer-dashboard.component';
import { EmployerProfileComponent } from './employer-profile/employer-profile.component';

const routes: Routes = [
  {
    path: '', component: EmployerDashboardComponent,
    children: [
      { path: '', component: DashboardComponent },
      { path: 'employerProfile', component: EmployerProfileComponent },
      { path: 'createJob', component: CreateJobComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployerDashboardRoutingModule { }
