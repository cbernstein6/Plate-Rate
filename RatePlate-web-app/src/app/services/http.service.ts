import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { RatingDto } from "../../../models/RatingDto";
import { UserProfile } from "../../../models/UserProfile";

@Injectable()
export class HttpRequest {
    constructor(private http: HttpClient){}

    PopularSchools(){
        return this.http.get('http://localhost:5119/api/College/GetPopular');
    }
    GetSchools(){
        return this.http.get('http://localhost:5119/api/College');
    }

    GetHallRatings(id: number) {
        return this.http.get(`http://localhost:5119/api/Rating/Hall/${id}`);
    }

    GetSchoolHalls(id: number){
        return this.http.get(`http://localhost:5119/api/Hall/CollegeHalls/${id}`);
    }

    GetRatingDetails(id: number){
        return this.http.get(`http://localhost:5119/api/Rating/HallDetails/${id}`);
    }
    

    GetUserId(email: string){
        return this.http.get(`http://localhost:5119/api/User/GetUser/${email}`);
    }
    CreateUser(user: UserProfile){
        return this.http.post('http://localhost:5119/api/User', user);
    }

    SendRating(form: RatingDto){
        return this.http.post('http://localhost:5119/api/Rating', form);
    }
}