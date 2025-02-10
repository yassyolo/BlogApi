import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginResponse } from './models/login-response.model';
import { BehaviorSubject, map, Observable } from 'rxjs';
import {jwtDecode} from 'jwt-decode'
import { LoginRequest } from './models/login-request.model';
import { RegisterRequest } from './models/register-request.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'https://localhost:5001/Auth';
  private currentUserSubject = new BehaviorSubject<LoginResponse | null>(null);
  currentUser$ = this.currentUserSubject.asObservable();

  constructor(private http: HttpClient) { 
    this.loadUserFromStorage();
  }

  private loadUserFromStorage() {
    const token = localStorage.getItem('token');
    if (token) {
      const decodedUser = this.decodeToken(token);
      this.currentUserSubject.next(decodedUser);
    }
  }

  login(request : LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`,  request ,{
       headers: new HttpHeaders().set('Content-Type', 'application/json')})
      .pipe(
      map((response: LoginResponse) => {
        localStorage.setItem('token', response.token);
        this.currentUserSubject.next(response);
        return response;
      })
    );
  }

  register(request: RegisterRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, { request });
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUserSubject.next(null);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getUserRole(): string[] {
    const token = this.getToken();
    if (!token) return [];
    const decoded = this.decodeToken(token);
    return decoded.roles || [];
  }

  private decodeToken(token: string): LoginResponse {
    return jwtDecode<LoginResponse>(token);
  }

  subscribeToNewsletter(email: string): void {
   this.http.post(`${this.apiUrl}/newsletter`, { email });
  }
}


