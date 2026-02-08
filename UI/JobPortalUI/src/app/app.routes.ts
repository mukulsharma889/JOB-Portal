import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./components/customer/customer-home/customer-home').then((x) => x.CustomerHome),
    children: [
      {
        path: '',
        redirectTo: 'jobs',
        pathMatch: 'full',
      },
      {
        path: 'jobs',
        loadComponent: () =>
          import('./components/customer/jobs-listing/jobs-listing').then((m) => m.JobsListing),
      },
    ],
  },
  {
    path: 'login',
    loadComponent: () => import('./core/auth/components/login/login').then((m) => m.Login),
  },
  {
    path: 'register',
    loadComponent: () => import('./core/auth/components/register/register').then((m) => m.Register),
  },
  {
    path: 'job-management',
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'jobs',
      },
      {
        path: 'jobs',
        loadComponent: () => import('./components/admin/jobs/jobs').then((m) => m.Jobs),
      },
    ],
  },
];
