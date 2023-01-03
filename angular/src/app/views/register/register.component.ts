import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { AuthenticationService } from "../../service/authentication.service";
import { RegisterUserModel } from "../../models/register-user.model";
import { ErrorMessage } from "../../models/error-message.model";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerUserModel: RegisterUserModel = <RegisterUserModel>{
    userName: '',
    password: '',
    email: ''
  };

  confirmPassword: string = "";
  errorMessages: ErrorMessage[] = [];

  constructor(private router: Router, private authenticationService: AuthenticationService) {}

  ngOnInit(): void {
  }

  submit(): void {
    this.errorMessages = [];
    console.log(this.confirmPassword)
    console.log(this.registerUserModel.password)
    if (this.confirmPassword === this.registerUserModel.password) {
      this.authenticationService.register(this.registerUserModel).subscribe(r => {
        this.errorMessages = r.errors;
        if (r.success) {
          this.router.navigate(['/', 'login']);
        }
      });
    } else {
      this.errorMessages.push({
        message: 'Passwords are not matching'
      })
    }
  }
}
