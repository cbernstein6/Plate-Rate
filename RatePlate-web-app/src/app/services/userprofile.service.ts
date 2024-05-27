import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserProfile } from '../../../models/UserProfile';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {

  constructor() { }

  profile: BehaviorSubject<any> = new BehaviorSubject<any>(null);

  setUserProfile(userProfile: UserProfile)
  {
    this.profile.next(userProfile);
  }

  getUserProfile()
  {
    return this.profile.asObservable();
  }
}
