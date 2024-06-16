import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { UserProfileService } from '../../../services/userprofile.service';
import { UserProfile } from '../../../../../models/UserProfile';

@Component({
  selector: 'app-user-role-prompt',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-role-prompt.component.html',
  styleUrl: './user-role-prompt.component.css'
})
export class UserRolePromptComponent {
  constructor(private router : Router, private profile : UserProfileService) { }
  
  private user : any;
  ngOnInit() {
    this.user = this.profile.getUserProfile();
  }

  userRoles : string[] = ['Student', 'Faculty', 'Professor', 'Alumni', 'Other'];

  selectedRole : string = this.userRoles[0];

  onSubmit(){
    this.user.role = this.selectedRole;
    this.profile.setUserProfile(this.user);
    
    this.router.navigate(['main']);
  }
}
