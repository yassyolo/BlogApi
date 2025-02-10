import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-footer',
  imports: [FormsModule],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css',
  standalone: true
})
export class FooterComponent {
  email: string = '';

  constructor(private authService: AuthService) { }

  subscribeToNewsletter() : void{
    if(this.email){
       this.authService.subscribeToNewsletter(this.email);
       this.email = '';
    }

  }
}
