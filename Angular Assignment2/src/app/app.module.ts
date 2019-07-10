import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './employee/employee.component';
import { RouterModule } from '@angular/router';
import { EmployeelistComponent } from './employee/employeelist/employeelist.component';
import { EmployeeeditComponent } from './employee/employeeedit/employeeedit.component';
import { EmployeeserviceService } from './employeeservice.service';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    EmployeelistComponent,
    EmployeeeditComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component:EmployeeComponent},
      { path: 'employee', component:EmployeeComponent},
      { path: 'employee/employeelist', component:EmployeelistComponent},
      { path: 'employee/employeeedit', component:EmployeeeditComponent},
      { path: 'employee/employeeedit/:firstName', component:EmployeeeditComponent},
    ])
  ],
  providers: [ EmployeeserviceService ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
