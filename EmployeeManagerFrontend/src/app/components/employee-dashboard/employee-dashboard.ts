import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { EmployeeService } from '../../services/employee';
import { EmployeeProfile } from '../../models/employee-profile';

@Component({
  selector: 'app-employee-dashboard',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './employee-dashboard.html',
  styleUrl: './employee-dashboard.css'
})
export class EmployeeDashboard implements OnInit {

  employee: EmployeeProfile | null = null;

  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {

    this.employeeService.getProfile().subscribe({

      next: (response: EmployeeProfile) => {

        console.log(response);

        this.employee = response;

      },

      error: (err) => {

        console.error(err);

      }

    });

  }

}