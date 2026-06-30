import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ManagerReport } from '../models/manager-report';
import { environment } from '../../environments/environment';
import { PendingRequest } from '../models/pending-request';
import { UpdateLeaveStatus } from '../models/update-leave-status';

@Injectable({
  providedIn: 'root'
})
export class ManagerService {

  private apiUrl = `${environment.apiUrl}/manager`;

  constructor(private http: HttpClient) {}
  getReport(): Observable<ManagerReport> {

  return this.http.get<ManagerReport>(
    `${this.apiUrl}/summary`
  );
}


getPendingRequests(): Observable<PendingRequest[]> {

  return this.http.get<PendingRequest[]>(
    `${this.apiUrl}/pendingrequests`
    
  );

}
approveLeave(
  id: number,
  request: UpdateLeaveStatus
) {

  return this.http.put(

    `${this.apiUrl}/approve/${id}`,

    request

  );

}
rejectLeave(
  id: number,
  request: UpdateLeaveStatus
) {

  return this.http.put(

    `${this.apiUrl}/reject/${id}`,

    request

  );

}

}