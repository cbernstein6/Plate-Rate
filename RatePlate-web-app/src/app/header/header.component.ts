import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HttpRequest } from '../services/http.service';
import { CommonModule } from '@angular/common';
import { FormGroup } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { UserProfileService } from '../services/userprofile.service';
import { UserProfile } from '../../../models/UserProfile';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})


export class HeaderComponent implements OnInit {

  profile!: UserProfile;
  isMenuVisible: boolean = false;
  
  constructor(private http: HttpRequest, private auth: AuthService, private userProfile : UserProfileService) {}

  ngOnInit(){
    this.userProfile.getUserProfile().subscribe(user => {
      this.profile = user;
    });
  }

  checkAuth(){
    return this.auth.checkObservable();
  }

  hasToken(){
    return this.auth.hasToken();
  }



  signOut(){
    this.auth.signOut();
  }

  changeMenuDisplay(){
    this.isMenuVisible = !this.isMenuVisible;
  }

}
