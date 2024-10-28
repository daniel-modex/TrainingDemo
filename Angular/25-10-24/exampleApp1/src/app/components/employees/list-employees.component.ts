import { Component } from '@angular/core';
import { Employee } from '../../models/employee';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-list-employees',
  standalone: true,
  imports: [DatePipe],
  templateUrl: './list-employees.component.html',
  styleUrl: './list-employees.component.css'
})
export class ListEmployeesComponent {
employees : Employee[] = [
  {
    id : 1,
    gender : 'Male',
    name : 'John',
    dateOfBirth : new Date('10-10-2000'),
    department : 'IT',
    isActive : true,
    email : 'john@gmail.com',
    phoneNumber : 234564758,
    contactPreference : 'yes',
    photoPath: 'employee_photos/john.png'
  },
  {
    id : 2,
    gender : 'Male',
    name : 'George',
    dateOfBirth : new Date('10-10-2000'),
    department : 'IT',
    isActive : true,
    email : 'george@gmail.com',
    phoneNumber : 234564758,
    contactPreference : 'yes',
    photoPath: 'employee_photos/george.png'
  },
  {
    id : 3,
    gender : 'Female',
    name : 'Mary',
    dateOfBirth : new Date('10-10-2000'),
    department : 'IT',
    isActive : true,
    email : 'mary@gmail.com',
    phoneNumber : 234564758,
    contactPreference : 'yes',
    photoPath: 'employee_photos/mary.png'
  }
]
}
