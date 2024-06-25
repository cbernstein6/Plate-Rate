import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { HttpRequest } from '../services/http.service';
import { RatingDto } from '../../../models/RatingDto';
import { ActivatedRoute, Router } from '@angular/router';
import { UserProfileService } from '../services/userprofile.service';
import { UserProfile } from '../../../models/UserProfile';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-rating-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatSnackBarModule],
  templateUrl: './rating-form.component.html',
  styleUrl: './rating-form.component.css'
})
export class RatingFormComponent {

  reviewForm!: FormGroup;
  categories = ['taste', 'atmosphere', 'location', 'service', 'cleanliness', 'menu', 'price'];
  
  title!: string;
  id!: number;
  location!: string;
  averageScore!: number;
  imagePath!: string;

  profile: UserProfile | null = null;

  constructor(private fb: FormBuilder, private http: HttpRequest, private route: ActivatedRoute,
      private userProfile : UserProfileService, private snackBar : MatSnackBar, private router : Router){

    this.reviewForm = this.fb.group({
      taste: '',
      atmosphere: '',
      location: '',
      service: '',
      cleanliness: '',
      menu: '',
      price: '',
      feedback: ''
    });

    this.route.queryParams.subscribe(res => {
      this.title = res['title'];
      this.id = res['id'];
      this.location = res['location'];
      this.averageScore = res['averageScore'];
      this.imagePath = res['imagePath'];
    })

  }

  ngOnInit() {
    this.userProfile.getUserProfile().subscribe(user => {
      this.profile = user;
    });
  }



  onSubmit() {
    var message = this.reviewForm.value.feedback;
    var taste = this.reviewForm.value.taste;
    var atmosphere = this.reviewForm.value.atmosphere;
    var location = this.reviewForm.value.location;
    var service = this.reviewForm.value.service;
    var cleanliness = this.reviewForm.value.cleanliness;
    var menu = this.reviewForm.value.menu;
    var price = this.reviewForm.value.price;

    // var 

    const ratingData: RatingDto = {
      Message: message,
      UserId: this.profile!.id,
      HallId: this.id,
      Taste: taste,
      Atmosphere: atmosphere,
      Location: location,
      Service: service,
      Cleanliness: cleanliness,
      Menu: menu,
      Price: price,
      FirstName: this.profile!.firstname,
    };
    
    this.http.SendRating(ratingData).subscribe(
      (response) => {
        this.snackBar.open('Rating submitted successfully!', 'Close', {
          duration: 2000,
          horizontalPosition: 'right',
          verticalPosition: 'bottom',
        });

        setTimeout(() => {
          this.router.navigate(['/hall'], { queryParams: {
            title: this.title,
            id: this.id,
            location: this.location,
            imagePath: this.imagePath,
            averageScore: this.averageScore
          }});
        }, 2000);
      },
      (error) => console.log(error)
    );
  }
}
