import { Component } from '@angular/core';
import { RegisterComponent } from '../auth/register/register.component';
import { LoginComponent } from '../auth/login/login/login.component';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-welcome',
  imports: [RegisterComponent, LoginComponent, RouterLink, CommonModule],
  templateUrl: './welcome.component.html',
  styleUrl: './welcome.component.css'
})
export class WelcomeComponent {
  constructor(private router: Router){}

  isLogin() : boolean{
    return this.router.url === '/login';
  }

}
