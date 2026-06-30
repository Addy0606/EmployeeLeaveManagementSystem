import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

import { ManagerService } from '../../services/manager';
import { ManagerReport } from '../../models/manager-report';

@Component({
  selector: 'app-manager-dashboard',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './manager-dashboard.html',
  styleUrl: './manager-dashboard.css'
})
export class ManagerDashboard implements OnInit {

  report: ManagerReport | null = null;

  constructor(private managerService: ManagerService) {}

  ngOnInit(): void {

    this.managerService.getReport().subscribe({

      next: (response: any) => {

        this.report = response;

      },

      error: (err: any) => {

        console.error(err);

      }

    });

  }

}