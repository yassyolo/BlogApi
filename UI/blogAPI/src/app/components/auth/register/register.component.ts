import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router, RouterLink } from '@angular/router';
import { last } from 'rxjs';
import { RegisterRequest } from '../models/register-request.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
  standalone: true
})
export class RegisterComponent implements OnInit {
 registerForm?: FormGroup;

 constructor(private authService: AuthService,
   private router: Router,
   private formsBuilder: FormBuilder) { 
    
   }
  ngOnInit(): void {
    this.registerForm = this.formsBuilder.group({
      username: ['', [Validators.required, Validators.minLength(0), Validators.maxLength(50)]],
      firstName: ['', [Validators.required, Validators.minLength(0), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(0), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email, Validators.minLength(0), Validators.maxLength(50)]],
      password: ['', [Validators.required, Validators.minLength(0), Validators.maxLength(50)]],
      confirmPassword: ['', [Validators.required, this.matchPasswords.bind(this)]]
    })
  }

   
  matchPasswords(control: any) : { [key: string]: boolean } | null{
    if(this.registerForm && control.value !== this.registerForm.get('password')?.value){
      return {passwordsDoNotMatch: true};
    }
    return null;
  }

  onSubmit() : void{
    if(this.registerForm?.valid){
      const request: RegisterRequest = this.registerForm.value;
      this.authService.register(request).subscribe({
        next: () => {
          this.router.navigate(['/login']);
        },
        error: (error) => {
          console.log('Registration failed', error);
        }
      });
    }
  }
}
