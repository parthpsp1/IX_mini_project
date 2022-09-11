import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenService } from 'src/app/core/services/token.service';

@Component({
  selector: 'app-employer-nav',
  templateUrl: './employer-nav.component.html',
  styleUrls: ['./employer-nav.component.scss']
})
export class EmployerNavComponent implements OnInit {

  imageSrc= '../../../assets/website_logo.png';
  websiteName = "Job Portal"

  constructor(private token: TokenService, private route: Router) { }

  ngOnInit(): void {
  }

  deleteToken() {
    this.token.deleteToken();
  }

  routeToLogin() {
    this.route.navigate(['employerLogin']);
  }
}
