import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  imageSrc= '../../../assets/website_logo.png';
  websiteName = "Job Portal";
  
  constructor() { }

  ngOnInit(): void {
  }

}
