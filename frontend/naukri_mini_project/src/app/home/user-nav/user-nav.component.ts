import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenService } from 'src/app/core/services/token.service';

@Component({
  selector: 'app-user-nav',
  templateUrl: './user-nav.component.html',
  styleUrls: ['./user-nav.component.scss']
})
export class UserNavComponent implements OnInit {


  imageSrc= '../../../assets/website_logo.png';

  constructor(private token: TokenService, private route: Router) { }

  ngOnInit(): void {
  }

  deleteToken() {
    this.token.deleteToken();
  }

  routeToLogin() {
    this.route.navigate(['userLogin']);
  }
}
