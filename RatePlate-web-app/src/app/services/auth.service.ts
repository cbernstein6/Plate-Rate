import { BehaviorSubject } from "rxjs";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root',  // This makes the service available in the root injector
})
export class AuthService {
    private currTokenVar = new BehaviorSubject<boolean>(this.hasToken());

    constructor(){}
    
    checkObservable(){
        return this.currTokenVar.asObservable();
    }

    hasToken(){
        // console.log("signed in: "+ localStorage.getItem("jwtToken") != null && localStorage.getItem("jwtToken") != "")
        let token: string | null = localStorage.getItem("jwtToken");
        return token != null && token != "";
    }

    signIn(token: string) {
        localStorage.setItem("jwtToken", token);
        this.currTokenVar.next(this.hasToken());
    }

    signOut() {
        localStorage.removeItem("jwtToken");
        this.currTokenVar.next(this.hasToken());
    }
}