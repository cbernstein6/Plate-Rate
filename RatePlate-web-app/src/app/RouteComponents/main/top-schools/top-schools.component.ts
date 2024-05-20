import { Component, EventEmitter, Output } from '@angular/core';
import { HttpRequest } from '../../../services/http.service';
import { CommonModule } from '@angular/common';
import { SchoolIconComponent } from "./school-icon/school-icon.component";

@Component({
    selector: 'app-top-schools',
    standalone: true,
    templateUrl: './top-schools.component.html',
    styleUrl: './top-schools.component.css',
    imports: [CommonModule, SchoolIconComponent]
})
export class TopSchoolsComponent {
  schools: any;

  constructor(private http : HttpRequest){}

  ngOnInit(){
    this.http.PopularSchools().subscribe(schools => {
      this.schools = Object.values(schools);
      // console.log(this.schools[0]);
    });
  }


  
  ngOnDestroy(){
    // this.http.unsub
  }
}
