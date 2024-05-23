import { Injectable } from '@angular/core';
import { SocialAuthService, GoogleLoginProvider, SocialUser } from 'angularx-social-login';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GoogleSignInService {
  constructor(private socialAuthService: SocialAuthService) {
    let config = {
      autoLogin: false,
      providers: [
        {
          id: GoogleLoginProvider.PROVIDER_ID,
          provider: new GoogleLoginProvider('877782930184-hsq6sjn6pkjht33lvv53nhu359k7n5kf.apps.googleusercontent.com')
        }
      ]
    };
    // socialAuthService.initialize(config);
  }

  signInWithGoogle(): void {
    this.socialAuthService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }

  signOut(): void {
    this.socialAuthService.signOut();
  }

  authState(): Observable<SocialUser> {
    return this.socialAuthService.authState;
  }
}