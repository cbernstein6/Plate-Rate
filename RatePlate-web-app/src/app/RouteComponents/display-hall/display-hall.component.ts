import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Subscription } from 'rxjs';
import { HttpRequest } from '../../services/http.service';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-display-hall',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './display-hall.component.html',
  styleUrl: './display-hall.component.css'
})
export class DisplayHallComponent {
  private querySubscription!: Subscription;

  title: any | null;
  location: any | null;
  imagePath: any | null;
  id: any | null;
  averageScore: any | null = 0;

  ratings: any[] = [];

  detailList: any;

  totalRatings: number = 20;

  
  
  constructor(private route: ActivatedRoute, private router: Router, private http: HttpRequest, private toastr: ToastrService){}

  ngOnInit() {
    this.querySubscription = this.route.queryParams.subscribe(params => {
      this.id = params['id'];
      this.title = params['name'];
      this.imagePath = params['imagePath'];
      this.location = params['location'];
    });


    this.http.GetHallRatings(this.id).subscribe((res) => {
      this.ratings = Object.values(res);
    });
    
    this.http.GetRatingDetails(this.id).subscribe((res) => {
      this.detailList = res;
    });

    // for(let detail of this.detailList)
    //   this.averageScore += detail
    // this.averageScore /= 7;

  }
  
  ngOnDestroy(){
    this.querySubscription.unsubscribe();
  }

  signedIn(){
    return localStorage.getItem("jwtToken") != null;
  }

  toastrErr(){
    if(!this.signedIn())
      this.toastr.error('Please sign in to add a rating','Error');
  }

  incRatings(){
    this.totalRatings += 20;
  }

  navigateOrError(){
    if(this.signedIn()){
      this.router.navigate(['/rating'], { queryParams: { id: this.id, title: this.title}});
    }else{
      this.toastr.error('Please sign in to add a rating');
    }
  }
}