import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';

import Nora from '@primeuix/themes/nora';
import { providePrimeNG } from 'primeng/config';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes),
    providePrimeNG({
      theme: {
        preset: Nora,
        options: {
          darkModeSelector: '.my-app-dark', // Optional: for dark mode toggling
        },
      },
    }),
  ],
};
