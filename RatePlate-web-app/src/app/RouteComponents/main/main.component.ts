import { Component } from '@angular/core';
import { HeaderComponent } from "../../header/header.component";
import { SearchComponent } from "./search/search.component";
import { TopSchoolsComponent } from "./top-schools/top-schools.component";
import { DisplaySchoolComponent } from "../display-school/display-school.component";

@Component({
    selector: 'app-main',
    standalone: true,
    templateUrl: './main.component.html',
    styleUrl: './main.component.css',
    imports: [HeaderComponent, SearchComponent, TopSchoolsComponent, DisplaySchoolComponent]
})
export class MainComponent {
    school: any;
    login: boolean = false;

    
  
  
    setLogin(val: boolean){
        this.login = true;
    }
  

}
