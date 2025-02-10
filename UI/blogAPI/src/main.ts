import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter, withComponentInputBinding, withDebugTracing, withHashLocation } from '@angular/router';
import { provideHttpClient } from '@angular/common/http'; 
import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes';


bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes, withDebugTracing()),
    provideHttpClient()
  ]
}).catch(err => console.error(err));

