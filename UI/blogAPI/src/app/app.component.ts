import { Component } from '@angular/core';
import { Router, RouterLink, RouterModule, RouterOutlet } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavbarComponent, FooterComponent, CommonModule, RouterModule],
  standalone : true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'blogAPI';
  isLoginOrRegisterPage: boolean = false;

  constructor(private router: Router){
    this.router.events.subscribe((val) => 
    this.isLoginOrRegisterPage = this.router.url.includes('login') || this.router.url.includes('register'));
  }
}
