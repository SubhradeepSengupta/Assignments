import { Component, OnInit } from '@angular/core';
import { EmployeeserviceService } from 'src/app/employeeservice.service';
import { Employee } from '../model/employee.model';
import { Router } from '@angular/router';
@Component({
  selector: 'app-employeeedit',
  templateUrl: './employeeedit.component.html',
  styleUrls: ['./employeeedit.component.css']
})
export class EmployeeeditComponent {

  employeedetails: Array<Employee>;

  constructor(private employee: EmployeeserviceService, private route: Router) {}

  ngOnInit() {
    this.employeedetails = this.employee.getDetails();
  }

  edit() {
    this.route.navigate(['/employee/employeelist']);
    }
}
