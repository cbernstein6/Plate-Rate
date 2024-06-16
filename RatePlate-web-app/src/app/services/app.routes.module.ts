import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from '../RouteComponents/main/main.component';
import { NgModule } from '@angular/core';
import { DisplaySchoolComponent } from '../RouteComponents/display-school/display-school.component';
import { DisplayHallComponent } from '../RouteComponents/display-hall/display-hall.component';
import { RatingFormComponent } from '../rating-form/rating-form.component';
import { AboutUsComponent } from '../header/about-us/about-us.component';
import { OurSchoolsComponent } from '../RouteComponents/our-schools/our-schools.component';
import { LoginComponent } from '../header/login/login.component';
import { UserRolePromptComponent } from '../header/login/user-role-prompt/user-role-prompt.component';
import { authGuard } from '../auth-guard.guard';


export const routes: Routes = [
    {path: '', component: LoginComponent},
    {path: 'main', component: MainComponent,  canActivate: [authGuard]},
    {path: 'login', component: LoginComponent},
    {path: 'school', component: DisplaySchoolComponent,  canActivate: [authGuard]},
    {path: 'hall', component: DisplayHallComponent,  canActivate: [authGuard]},
    {path: 'rating', component: RatingFormComponent, canActivate: [authGuard]},
    {path: 'aboutus', component: AboutUsComponent,  canActivate: [authGuard]},
    {path: 'ourschools', component: OurSchoolsComponent,  canActivate: [authGuard]},
    {path: 'role-prompt', component: UserRolePromptComponent,  canActivate: [authGuard]},
    {path: '**', redirectTo: 'main'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}