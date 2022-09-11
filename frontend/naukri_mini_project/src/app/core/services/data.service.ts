import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  baseUserAPI = "https://localhost:44303/api/User";
  baseUserRegistrationAPI = "https://localhost:44303/api/UserAuthentication/registerUser";
  baseUserLoginAPI = "https://localhost:44303/api/UserAuthentication/loginUser";

  baseEmployerAPI = "https://localhost:44303/api/Employer";
  baseEmployerRegistrationAPI = "https://localhost:44303/api/UserAuthentication/registerEmployer";
  baseEmployerLoginAPI = "https://localhost:44303/api/UserAuthentication/loginEmployer";

  baseJobsAPI = "https://localhost:44303/api/Job";

  constructor(private httpclient: HttpClient, private token: TokenService) { }

  //User

  registerUser(registerUser: string): Observable<any> {
    return this.httpclient.post("https://localhost:44303/api/UserAuthentication/registerUser", registerUser)
  }

  loginUser(loginUser: string): Observable<any> {
    return this.httpclient.post(this.baseUserLoginAPI, loginUser);
  }

  getUser(): Observable<any> {
    const headers = {Authorization:`Bearer ${this.token.getToken()}`};
    return this.httpclient.get(this.baseUserAPI, {headers: headers});
  }

  addUser(data: string): Observable<any> {
    return this.httpclient.post(this.baseUserAPI, data);
  }

  updateUser(data: string): Observable<any> {
    return this.httpclient.put(this.baseUserAPI, data);
  }

  deleteUser(): Observable<any> {
    return this.httpclient.delete(this.baseUserAPI);
  }

  //Employer

  registerEmployer(registerUser: string): Observable<any> {
    return this.httpclient.post(this.baseEmployerRegistrationAPI, registerUser)
  }

  loginEmployer(loginUser: string): Observable<any> {
    return this.httpclient.post(this.baseEmployerLoginAPI, loginUser);
  }

  getEmployer(): Observable<any> {
    const headers = {Authorization:`Bearer ${this.token.getToken()}`};
    const get_employers = this.baseEmployerAPI;
    return this.httpclient.get(get_employers, {headers: headers});
  }

  addEmployer(data: string): Observable<any> {
    const add_employer = this.baseEmployerAPI;
    return this.httpclient.post(add_employer, data);
  }

  updateEmployer(data: string): Observable<any> {
    const update_employer = this.baseEmployerAPI;
    return this.httpclient.put(update_employer, data);
  }

  deleteEmployer(): Observable<any> {
    const delete_employer = this.baseEmployerAPI;
    return this.httpclient.delete(delete_employer);
  }

  //Jobs

  getJobs(): Observable<any> {
    const get_jobs = this.baseJobsAPI;
    return this.httpclient.get(get_jobs);
  }

  addjob(data: string): Observable<any> {
    const add_job = this.baseJobsAPI;
    return this.httpclient.post(add_job, data);
  }

  updatejob(data: string): Observable<any> {
    const update_job = this.baseJobsAPI;
    return this.httpclient.put(update_job, data);
  }

  deletejob(): Observable<any> {
    const delete_job = this.baseJobsAPI;
    return this.httpclient.delete(delete_job);
  }
}
