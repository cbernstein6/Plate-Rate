import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { HttpRequest } from '../services/http.service';
import { RatingDto } from '../../../models/RatingDto';
import { ActivatedRoute } from '@angular/router';
import { ToastrService, ToastNoAnimation } from 'ngx-toastr';

@Component({
  selector: 'app-rating-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './rating-form.component.html',
  styleUrl: './rating-form.component.css'
})
export class RatingFormComponent {

  reviewForm!: FormGroup;
  categories = ['taste', 'atmosphere', 'location', 'service', 'cleanliness', 'menu', 'price'];
  title!: string;
  id!: number;

  constructor(private fb: FormBuilder, private http: HttpRequest, private route: ActivatedRoute, private toastr: ToastrService){
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
    })
  }



  onSubmit() {
    var message = this.reviewForm.value.feedback;
    var taste = this.reviewForm.value.taste;
    var atmosphere = this.reviewForm.value.atmosphere;
    var location = this.reviewForm.value.location;
    var service = this.reviewForm.value.service;
    console.log(service);
    var cleanliness = this.reviewForm.value.cleanliness;
    var menu = this.reviewForm.value.menu;
    var price = this.reviewForm.value.price;

    // var 

    const ratingData: RatingDto = {
      Score: 0.5,
      Message: message,
      UserId: Number(localStorage.getItem('userId')),
      HallId: this.id,
      Taste: taste,
      Atmosphere: atmosphere,
      Location: location,
      Service: service,
      Cleanliness: cleanliness,
      Menu: menu,
      Price: price

    };
    
    this.http.SendRating(ratingData,localStorage.getItem("jwtToken")!).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => this.toastr.info('Please fill out all fields', 'Error', { positionClass: 'toast-bottom-right' })
    );
  }
}
