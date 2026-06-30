import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeService } from '../../services/employee';
import { LeaveHistory } from '../../models/leave-history';
import { EmployeeNavbarComponent } from '../employee-navbar/employee-navbar';

@Component({
  selector: 'app-leave-history',
  standalone: true,
  imports: [CommonModule,EmployeeNavbarComponent],
  templateUrl: './leave-history.html',
  styleUrl: './leave-history.css'
})
export class LeaveHistoryComponent implements OnInit {

  leaves: LeaveHistory[] = [];

  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {

    this.employeeService.getLeaveHistory().subscribe({

      next: (response) => {

        this.leaves = response;

      },

      error: (err) => {

        console.error(err);

      }

    });

  }

}