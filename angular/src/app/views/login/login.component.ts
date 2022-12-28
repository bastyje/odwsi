import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AuthenticationService } from "../../service/authentication.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private router: Router, formBuilder: FormBuilder, private authenticationService: AuthenticationService) {
    this.loginForm = formBuilder.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {}

  submit(): void {
    console.log(this.loginForm.value);
    console.log(this.authenticationService.signIn(this.loginForm.value));
    // this.router.navigate(['/', 'notes']);
  }
}
