import { BehaviorSubject, Observable } from "rxjs";
import { Injectable, NgZone } from "@angular/core";
import { Router } from "@angular/router";

@Injectable({
    providedIn: 'root',  // This makes the service available in the root injector
})
export class AuthService {
    private currTokenVar = new BehaviorSubject<boolean>(this.hasToken());

    constructor(private router : Router, private ngZone : NgZone) {
    }
    
    checkObservable() : Observable<boolean> {
        return this.currTokenVar.asObservable();
    }

    hasToken(){
        const token: string | null = localStorage.getItem("auth_token");
        return token != null && token != "";
    }

    signIn(token: string) {
        localStorage.setItem('auth_token', token);
        this.ngZone.run(() => {
            this.currTokenVar.next(true);
        });
    }

    signOut() {
        localStorage.removeItem('auth_token');
        this.ngZone.run(() => {
        this.currTokenVar.next(false);
        this.router.navigate(['/login']);
        });
    }
}