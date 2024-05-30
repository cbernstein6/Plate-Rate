import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserProfile } from '../../../models/UserProfile';
import { jwtDecode } from 'jwt-decode';
import { Router } from '@angular/router';
import { HttpRequest } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {

  constructor(private router : Router, private http : HttpRequest) {
    this.initializeUserProfile();
  }

  

  profile: BehaviorSubject<any> = new BehaviorSubject<any>(null);

  setUserProfile(userProfile: UserProfile)
  {
    this.profile.next(userProfile);
  }

  getUserProfile()
  {
    return this.profile.asObservable();
  }

  
  initializeUserProfile(){

    const token: any = localStorage.getItem('auth_token');
    const decodedToken: any = jwtDecode(token);

    this.http.GetUserId(decodedToken).subscribe(data => {
      let  userId: any = data;

      let user: any = {
        id: userId,
        email: decodedToken.email,
        firstname: decodedToken.given_name,
        lastname: decodedToken.family_name,
        picture: decodedToken.picture
      };

      if(userId == -1){
        this.http.CreateUser(user).subscribe(data => {
          user.id = data;
        });
      }

      this.setUserProfile(user);
    })
  }
}
