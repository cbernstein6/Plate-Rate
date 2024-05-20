import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UserLoginDto } from "../../../models/UserLoginDto";
import { FormGroup } from "@angular/forms";
import { RatingDto } from "../../../models/RatingDto";
import { UserSignupDto } from "../../../models/UserSignupDto";

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
    

    AddUser(user: UserSignupDto){
        // console.log("sending");
        
        return this.http.post('http://localhost:5119/api/User',user);
    }

    Login(loginInfo: UserLoginDto){
        return this.http.post('http://localhost:5119/api/User/login', loginInfo);
    }

    
    SendRating(form: RatingDto, token: string){
        if(token == null || token == undefined) 
            throw Error("Please sign in to send a rating");

        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + token
            })
        }
        
        return this.http.post('http://localhost:5119/api/Rating', form, httpOptions);
    }
}