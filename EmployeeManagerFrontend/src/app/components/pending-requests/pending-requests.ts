import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ManagerService } from '../../services/manager';

import { PendingRequest } from '../../models/pending-request';
import { UpdateLeaveStatus } from '../../models/update-leave-status';

@Component({
  selector: 'app-pending-requests',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './pending-requests.html',
  styleUrl: './pending-requests.css'
})
export class PendingRequestsComponent implements OnInit {

  requests: PendingRequest[] = [];

  constructor(private managerService: ManagerService) {}

  ngOnInit(): void {

    this.loadRequests();

  }

  loadRequests() {

    this.managerService.getPendingRequests().subscribe({

      next: (response: PendingRequest[]) => {

        this.requests = response.map(request => ({

          ...request,

          managerComment: ''

        }));

      },

      error: (err: any) => {

        console.error(err);

      }

    });

  }
  approve(request: PendingRequest): void {

  this.managerService.approveLeave(
    request.leaveRequestId,
    {
      managerComment: request.managerComment
    }
  ).subscribe({

    next: () => {

      alert("Leave approved.");

      this.loadRequests();

    },

    error: (err: any) => {

      console.error(err);

    }

  });

}

reject(request: PendingRequest): void {

  this.managerService.rejectLeave(
    request.leaveRequestId,
    {
      managerComment: request.managerComment
    }
  ).subscribe({

    next: () => {

      alert("Leave rejected.");

      this.loadRequests();

    },

    error: (err: any) => {

      console.error(err);

    }

  });

}

}