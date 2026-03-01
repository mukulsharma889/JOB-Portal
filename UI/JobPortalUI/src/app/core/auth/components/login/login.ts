import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { PasswordModule } from 'primeng/password';
import { environment } from '../../../../../environments/environment';

@Component({
  selector: 'app-login',
  imports: [CommonModule, PasswordModule, FormsModule, ButtonModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  title = signal<string>(environment.appName);
  credentials = {
    email: '',
    password: '',
  };

  onLogin() {
    console.log('Static Login Data:', this.credentials);
    alert(`Attempting login for: ${this.credentials.email}`);
  }
}
