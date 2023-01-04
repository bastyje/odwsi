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

  passwordEntropy: number = 0;
  confirmPassword: string = "";
  errorMessages: ErrorMessage[] = [];

  constructor(private router: Router, private authenticationService: AuthenticationService) {
  }

  ngOnInit(): void {
  }

  cancel(): void {
    this.router.navigate(['/', 'login']);
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

  strong(): boolean {
    return 3.5 < this.passwordEntropy;
  }

  medium(): boolean {
    return 2.5 < this.passwordEntropy && this.passwordEntropy <= 3.5;
  }

  weak(): boolean {
    return this.passwordEntropy <= 2.5;
  }

  entropy(str: string) {
    return [...new Set(str)]
      .map(chr =>  str.match(new RegExp(chr, 'g'))?.length ?? 0)
      .reduce((sum, frequency) => {
        if (frequency === undefined || sum === undefined) return 0;
        let p = frequency / str.length;
        return sum + p * Math.log2(1 / p);
      }, 0);
  };

  onInput(): void {
    this.passwordEntropy = this.entropy(this.registerUserModel.password);
    console.log(this.passwordEntropy)
  }
}
