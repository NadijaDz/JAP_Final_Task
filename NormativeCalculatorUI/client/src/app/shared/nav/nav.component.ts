import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { first } from 'rxjs/operators';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { LoginService } from 'src/app/core/services/login.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  cookieValue: any;
  isUserLoggedIn: boolean = false;

  constructor(
    private authenticationService: AuthenticationService
  ) {}

  ngOnInit() {
    this.isUserLoggedIn = this.authenticationService.isUserLoggedIn;
  }

  logout() {
    this.authenticationService.logout();
  }
}
