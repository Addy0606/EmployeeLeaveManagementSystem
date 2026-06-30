import { Component } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';

import { AuthService } from '../../services/auth';
  
@Component({
  selector: 'app-employee-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './employee-navbar.html',
  styleUrl: './employee-navbar.css'
})
export class EmployeeNavbarComponent {

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  logout() {

    this.authService.logout();

    this.router.navigate(['/']);

  }

}