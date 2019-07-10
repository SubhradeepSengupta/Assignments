import { Component, OnInit, Output } from '@angular/core';
import { Employee } from './model/employee.model';
import { EmployeeserviceService } from '../employeeservice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-emp',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  
  EmployeeObject = new Employee(null, '', '', '', null, '', '', '', '', '', '', []);
  userQualification: string[];
  userExperience: string[];
  coding: any[];

  constructor(private _emp: EmployeeserviceService, private router: Router) { }

  ngOnInit() {
    this.userQualification = ['10th', '12th', 'Graduation'];
    this.userExperience = ['1_Year', '2_Year', '3_Year'];
    this.coding = [
      { langName: 'C/C++', isEnabled: false },
      { langName: 'Java', isEnabled: true },
      { langName: 'C#', isEnabled: true },
      { langName: 'PHP', isEnabled: false },
      { langName: 'Python', isEnabled: false }
    ];
  }

  getQual(Qualification: string) {
    alert(Qualification);
  }

  languageCheck(languages: string, event): void {
    if (event.target.checked) {
      this.EmployeeObject.userCoding.push(languages);
    }
    else if (!event.target.checked) {
      var num = this.EmployeeObject.userCoding.indexOf(languages);
      this.EmployeeObject.userCoding.splice(num, 1);
    }
  }

  getDetails() {
    console.log(this.EmployeeObject);
    this.EmployeeObject.id = (Math.round(Math.random()*100)+1);
    this._emp.addDetails(this.EmployeeObject);
    this.router.navigate(['/employee/employeelist']);
  }



}
