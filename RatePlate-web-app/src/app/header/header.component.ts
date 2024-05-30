import { Component, ElementRef, EventEmitter, HostListener, OnInit, Output } from '@angular/core';
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

  profile: UserProfile | null = null;
  isMenuVisible: boolean = false;
  
  constructor(private auth: AuthService, private userProfile : UserProfileService, private elementRef : ElementRef) {}

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

  @HostListener('document:click', ['$event'])
  clickOutside(event: MouseEvent) {
    if(!this.elementRef.nativeElement.contains(event.target) && this.isMenuVisible) {
      this.changeMenuDisplay();
    }
  }

}
