import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from "../../../../service/authentication.service";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
  }

  logout(): void {
    this.authenticationService.signOut();
  }
}
