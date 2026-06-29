import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = `${environment.apiUrl}/auth`;

  constructor(private http: HttpClient) { }

  login(request: any): Observable<any> {
    return this.http.post<any>(
      `${this.apiUrl}/login`,
      request
    );
  }
  getProfile(): Observable<any> {

  return this.http.get(
    `${environment.apiUrl}/employee/profile`
  );

}
  saveAuthData(response: any): void {
    localStorage.setItem('token', response.token);
    localStorage.setItem('role', response.role);
    localStorage.setItem('name', response.name);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getRole(): string | null {
    return localStorage.getItem('role');
  }

  getName(): string | null {
    return localStorage.getItem('name');
  }

  isLoggedIn(): boolean {
    return this.getToken() !== null;
  }

  logout(): void {
    localStorage.clear();
  }

}