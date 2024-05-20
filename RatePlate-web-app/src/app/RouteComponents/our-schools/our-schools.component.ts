import { Component } from '@angular/core';
import { TopSchoolsComponent } from "../main/top-schools/top-schools.component";
import { HttpRequest } from '../../services/http.service';
import { SchoolIconComponent } from "../main/top-schools/school-icon/school-icon.component";
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-our-schools',
    standalone: true,
    templateUrl: './our-schools.component.html',
    styleUrl: './our-schools.component.css',
    imports: [TopSchoolsComponent, SchoolIconComponent, CommonModule]
})
export class OurSchoolsComponent {
    schools: any;

    constructor(private http: HttpRequest){}

    ngOnInit(){
        this.http.GetSchools().subscribe(data => {
            this.schools = Object.values(data);
        }, 
        err => console.log(err)
        );
    }
}
