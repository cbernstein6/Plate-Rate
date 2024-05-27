import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { jwtDecode } from 'jwt-decode';
import { UserProfileService } from '../../services/userprofile.service';

declare var google: any;

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [],
  templateUrl: './login.component.html',
styleUrl: './login.component.css'
})
export class LoginComponent {
  private clientId: string = '877782930184-hsq6sjn6pkjht33lvv53nhu359k7n5kf.apps.googleusercontent.com';

  constructor(private auth : AuthService, private userProfile : UserProfileService){}


  ngOnInit() {
    window['handleCredentialResponse'] = this.handleCredentialResponse.bind(this);

    // Manually initialize the Google Sign-In button
    google.accounts.id.initialize({
      client_id: this.clientId,
      callback: this.handleCredentialResponse.bind(this)
    });
    google.accounts.id.renderButton(
      document.getElementById('buttonDiv'),
      { theme: 'outline', size: 'large' }  // customization attributes
    );
    google.accounts.id.prompt(); // also display the One Tap dialog
  }

  handleCredentialResponse(response: any){
    this.auth.signIn(response.credential);
    const decodedToken: any = jwtDecode(response.credential);
    // console.log(decodedToken);

    const user: any = {
      username: decodedToken.given_name,
      email: decodedToken.email,
      picture: decodedToken.picture
    };
    this.userProfile.setUserProfile(user);
  }
}
