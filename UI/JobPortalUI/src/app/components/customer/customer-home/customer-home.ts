import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Footer } from '../../../core/layout/footer/footer';
import { Header } from '../../../core/layout/header/header';

@Component({
  selector: 'app-customer-home',
  imports: [Header, Footer, RouterOutlet],
  templateUrl: './customer-home.html',
  styleUrl: './customer-home.scss',
})
export class CustomerHome {}
