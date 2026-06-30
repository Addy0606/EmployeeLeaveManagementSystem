import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { EmployeeService } from '../../services/employee';
import { ApplyLeave } from '../../models/apply-leave';
import { EmployeeNavbarComponent } from '../employee-navbar/employee-navbar';

@Component({
  selector: 'app-apply-leave',
  standalone: true,
  imports: [FormsModule,EmployeeNavbarComponent],
  templateUrl: './apply-leave.html',
  styleUrl: './apply-leave.css'
})
export class ApplyLeaveComponent {

  leaveRequest: ApplyLeave = {

    leaveTypeId: 1,

    startDate: '',

    endDate: '',

    reason: ''

  };

  constructor(
    private employeeService: EmployeeService,
    private router: Router
  ) {}

  async applyLeave() {

  this.employeeService.applyLeave(this.leaveRequest).subscribe({

    next: async () => {

      alert("Leave applied successfully!");

      const success = await this.router.navigate(['/leave-history']);

      console.log(success);

    }

  });

}

}