import { Component, NgZone } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './header/login/login.component';
import { HttpRequest } from './services/http.service'
import { MainComponent } from "./RouteComponents/main/main.component";
import { Routes, RouterModule, RouterOutlet } from '@angular/router';
import { CredentialResponse, PromptMomentNotification } from 'google-one-tap';
import { AuthService } from './services/auth.service';
import { CommonModule } from '@angular/common';
import { Observable, tap } from 'rxjs';
import { UserProfileService } from './services/userprofile.service';


declare global {
  interface Window {onGoogleLibraryLoad: any}
}



@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    providers: [HttpRequest, UserProfileService],
    imports: 
    [
      HeaderComponent, 
      RouterOutlet, 
      HttpClientModule, 
      RouterModule, 
      LoginComponent, 
      CommonModule
    ]
})


export class AppComponent {
  title = 'RatePlate-web-app';
  userId: number = -1;
  
  users: any;

  constructor(private auth : AuthService, private ngZone : NgZone){}

  ngOnInit() {
    
  }

  checkSignedIn(): Observable<boolean> {
    return this.auth.checkObservable().pipe(
      tap(() => this.ngZone.run(() => {}))
    );
  }
}
