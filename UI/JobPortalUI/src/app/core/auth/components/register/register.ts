import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { RadioButtonModule } from 'primeng/radiobutton';
import { environment } from '../../../../../environments/environment';

@Component({
  selector: 'app-register',
  imports: [
    CommonModule,
    FormsModule,
    InputTextModule,
    PasswordModule,
    RadioButtonModule,
    ButtonModule,
    RouterLink,
  ],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {
  title = signal<string>(environment.appName);
  user = {
    fullName: '',
    email: '',
    password: '',
    role: 'seeker', // Default role: Job Seeker
  };

  onRegister() {
    console.log('Static Registration Data:', this.user);
    alert(`Account created for ${this.user.fullName} as a ${this.user.role}!`);
  }
}
