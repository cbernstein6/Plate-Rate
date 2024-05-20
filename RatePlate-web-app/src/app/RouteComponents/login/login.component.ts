import { Component } from '@angular/core';
import { HeaderComponent } from "../../header/header.component";
import { CommonModule } from '@angular/common';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpRequest } from '../../services/http.service';
import { UserLoginDto } from '../../../../models/UserLoginDto';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../services/auth.service';
import { UserSignupDto } from '../../../../models/UserSignupDto';


@Component({
    selector: 'app-login',
    standalone: true,
    templateUrl: './login.component.html',
    styleUrl: './login.component.css',
    imports: [HeaderComponent, CommonModule, FormsModule, ReactiveFormsModule, HttpClientModule]
})
export class LoginComponent {

    myForm!: FormGroup;

    constructor(private formBuilder: FormBuilder, private http: HttpRequest, private toastr: ToastrService, private auth: AuthService){}

    ngOnInit(){
        this.myForm = this.formBuilder.group({
            username: ['', [Validators.required, Validators.minLength(5)]],
            password: ['', [Validators.required, Validators.minLength(8)]],
            confirmPassword: ['', [Validators.required, Validators.minLength(8)]]
        });
    }

    onLoginSubmit(){
        var username = this.myForm.value.username;
        var password = this.myForm.value.password;
        

        const loginData: UserLoginDto = {
            id: -1,
            UserName: username,
            Password: password
        };

        this.http.Login(loginData).subscribe(
            (response) => {
                let token: string = Object.values(response)[0];
                let userId: number = Object.values(response)[1];
                localStorage.setItem('userId', userId.toString());
                this.auth.signIn(token);
            },
            (error) => this.toastr.error("User Not Found")
        );
        
        
    }

    onSignUpSubmit(){
        var username = this.myForm.value.username;
        var password = this.myForm.value.password;
        var confirmPassword = this.myForm.value.confirmPassword;

        const userSignupDto: UserSignupDto = {
            UserName: username,
            Password: password,
            RedoPassword: confirmPassword
        };
        
        this.http.AddUser(userSignupDto).subscribe(
            (response) => {
                

                const loginData: UserLoginDto = {
                    id: -1,
                    UserName: username,
                    Password: password
                };
                this.http.Login(loginData).subscribe(
                    (response) => {
                        let token: string = Object.values(response)[0];
                        this.auth.signIn(token);
                    },
                    (error) => {}
                )
            },
            (error) => {
                console.log(error);
            }
        );
    }
}
