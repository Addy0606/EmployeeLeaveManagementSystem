import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LeaveHistory } from '../models/leave-history';
import { environment } from '../../environments/environment';
import { EmployeeProfile } from '../models/employee-profile';
import { ApplyLeave } from '../models/apply-leave';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private apiUrl = `${environment.apiUrl}/employee`;

  constructor(private http: HttpClient) {}

  getProfile(): Observable<EmployeeProfile> {
  return this.http.get<EmployeeProfile>(
    `${this.apiUrl}/profile`
  );
}
getLeaveHistory(): Observable<LeaveHistory[]> {

  return this.http.get<LeaveHistory[]>(

    `${this.apiUrl}/leaves`

  );

}
applyLeave(request: ApplyLeave) {

  return this.http.post(
    `${this.apiUrl}/applyleave`,
    request
  );

}


}