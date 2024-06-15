// import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideRouter } from '@angular/router';
import { routes } from './app/services/app.routes.module';
import { appConfig } from './app/app.config';

// import { provideAnimations } from '@angular/platform-browser/animations';
// import { importProvidersFrom } from '@angular/core';
// import { MatSnackBarModule } from '@angular/material/snack-bar';


// Merge appConfig with the router provider
const config = {
  ...appConfig,
  providers: [provideRouter(routes), provideAnimations(), importProvidersFrom(MatSnackBarModule)],
};

bootstrapApplication(AppComponent, config)
  .catch((err) => console.error(err));