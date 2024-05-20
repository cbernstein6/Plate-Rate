import { HttpRequest } from '../../services/http.service';
import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { HallViewComponent } from "./hall-view/hall-view.component";
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-display-school',
    standalone: true,
    templateUrl: './display-school.component.html',
    styleUrl: './display-school.component.css',
    imports: [HallViewComponent, CommonModule]
})
export class DisplaySchoolComponent {
  @Input() schoolDisplay: any;

  title: any | null;
  location: any | null;
  imagePath: any | null;
  id: any | null;
  halls: any | null;

  private querySubscription!: Subscription;


  constructor(private http: HttpRequest, private route: ActivatedRoute){}

  ngOnInit() {
    this.querySubscription = this.route.queryParams.subscribe(params => {
      this.id = params['id'];
      this.title = params['title'];
      this.imagePath = params['image'];
      this.location = params['location'];
    });


    this.http.GetSchoolHalls(this.id).subscribe(res => {
      this.halls = Object.values(res);
      // console.log(this.halls[0]);
    })
  }


  ngOnDestroy() {
    this.querySubscription.unsubscribe();
  }
}
