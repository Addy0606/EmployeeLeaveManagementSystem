import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {

  loginRequest = {
    email: '',
    password: ''
  };

  constructor(
  private authService: AuthService,
  private router: Router
) {}

  login(): void {
    this.authService.login(this.loginRequest).subscribe({
    next: (response: any) => {

  this.authService.saveAuthData(response);

  if (response.role === 'Employee') {

    this.router.navigate(['/employee-dashboard']);

  }
  else {

    this.router.navigate(['/manager-dashboard']);

  }

},
      error: (error: any) => {
        console.error(error);
      }
    });
  }
}