import { EmployeeUploadComponent } from './employee/components/employee-upload/employee-upload.component';
import { ListComponent } from './reusable-components/list/list.component';
import { JdListComponent } from './jd-list/jd-list.component';
import { ScheduleInterviewComponent } from './schedule-interview/schedule-interview.component';
import { CandidateFormComponent } from './candidate-form/candidate-form.component';
import { JdFormComponent } from './jd-form/jd-form.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateInterviewComponent } from './create-interview/create-interview.component';
import { HrInterviewAssessementComponent } from './hr-interview-assessement/hr-interview-assessement.component';
import { EmployeeFormComponent } from './employee/components/employee-form/employee-form.component';
import { EmployeeComponent } from './employee/containers/employee/employee.component';
import { JdPdfComponent } from './jd-form/jd-pdf/jd-pdf.component'
import { HrComponent } from './hr/hr.component';
import { AppNavBarComponent } from './nav-bar/nav-bar.component';
import { RoleGuardService } from './utilities/role-guard.service';

const routes: Routes = [
  { path: "", redirectTo: 'login', pathMatch: 'full'},
  { path: "login", component: LoginComponent },
  { path: "admin", component: AppNavBarComponent, canActivate: [RoleGuardService], data: {role: "admin"}, children: [
    {
      path: "", redirectTo: "home", pathMatch: "full"
    },
    {
      path: "home", component: HrComponent
    },
    {
      path: "employee", component: EmployeeComponent
    }
  ]},
  { path: "hr", component: AppNavBarComponent, canActivate: [RoleGuardService], data: {role: "hr"}, children: [
    {
      path: "", redirectTo: "home", pathMatch: "full"
    },
    {
      path: "home", component: HrComponent
    },
    {
      path: "job-desc", component: JdListComponent
    }
  ]},
  { path: "user", component: AppNavBarComponent, canActivate: [RoleGuardService], data: {role: "user"}, children: [
    {
      path: "", redirectTo: "home", pathMatch: "full"
    },
    {
      path: "home", component: HrComponent
    }
  ]},
  { path: "list", component: ListComponent },
  { path: "scedule-interview", component: ScheduleInterviewComponent },
  { path: "candidate", component: CandidateFormComponent },
  { path: "create-interview", component: CreateInterviewComponent },
  { path: "form", component: JdFormComponent },
  { path: "hr/assessement", component: HrInterviewAssessementComponent },
  {
    path: "", component: LoginComponent
  },
  { path: "hr/assessement", component: HrInterviewAssessementComponent },
  {
    path: "navbar", children: [
      {
        path: "", redirectTo: "dashboard", pathMatch: "full"
      },
      {
        path: "dashboard", component: DashboardComponent
      },
      {
        path: "jobs", component: JdListComponent
      },
      {
        path: "hr/dashboard", component: HrComponent
      }
    ]
  },
  // { path: 'employee/:formType', 
  //   children: [
  //     { path: '', component: EmployeeComponent, pathMatch: 'full' },
  //     { path: ':employeeId', component: EmployeeComponent }
  //   ]
  // },
  {
    path: 'employee', pathMatch: 'full',
    children: [
      { path: '', component: EmployeeComponent }
    ]
  },
  {
    path: 'jd-pdf',
    children: [
      { path: ':jdId', component: JdPdfComponent }
    ],
  },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
