import { Component } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './RouteComponents/login/login.component';
import { HttpRequest } from './services/http.service'
import { MainComponent } from "./RouteComponents/main/main.component";
import { Routes, RouterModule, RouterOutlet } from '@angular/router';




@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    providers: [HttpRequest],
    imports: [HeaderComponent, RouterOutlet, HttpClientModule, RouterModule]
})


export class AppComponent {
  title = 'RatePlate-web-app';
  userId: number = -1;
  
  users: any;

  
  
  routes: Routes = [
    {path: '', component: MainComponent},
    {path: 'main', component: MainComponent},
    {path: 'login', component: LoginComponent},
  ];

  ngOnInit(){}
}
