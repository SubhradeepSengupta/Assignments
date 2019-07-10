import { Injectable } from '@angular/core';
import { Employee } from './employee/model/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeserviceService {

  employee: Array<Employee>;   //Employee type array

  constructor() {
    this.employee = new Array<Employee>();
   }

  addDetails(emp: Employee) {
    this.employee.push(emp);
    //console.log(this.employee);
  }

  getDetails() {
    return this.employee;
  }
}
