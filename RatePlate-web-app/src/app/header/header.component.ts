import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HttpRequest } from '../services/http.service';
import { CommonModule } from '@angular/common';
import { FormGroup } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})


export class HeaderComponent implements OnInit{

  @Output() loginReq = new EventEmitter<boolean>();
  login: boolean = false;
  users: any;


  
  // signUpForm: FormGroup;
  
  constructor(private http: HttpRequest, private auth: AuthService) {}

  ngOnInit(){
    
    // this.http.GetUserList().subscribe(users => {
    //   this.users = users;
    // })

    // console.log(this.users);
    
  }

  checkAuth(){
    return this.auth.checkObservable();
  }

  signOut(){
    this.auth.signOut();
  }


  showLogin(){
    this.login = true;
    this.loginReq.emit(this.login);
  }

  
  
}
