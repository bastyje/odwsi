import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AuthenticationService } from "../../service/authentication.service";
import { ErrorMessage } from "../../models/error-message.model";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  errorMessages: ErrorMessage[] = [];

  constructor(private router: Router, formBuilder: FormBuilder, private authenticationService: AuthenticationService) {
    this.loginForm = formBuilder.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {}

  submit(): void {
    this.errorMessages = [];
    this.authenticationService.signIn(this.loginForm.value).then(_ => this.router.navigate(['/'])).catch(e => {
      if (e.status === 400) {
        this.errorMessages.push({
          message: "Wrong username or password"
        });
      }
    });
  }
}
