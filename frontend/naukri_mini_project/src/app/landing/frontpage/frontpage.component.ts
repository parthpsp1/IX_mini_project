import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-frontpage',
  templateUrl: './frontpage.component.html',
  styleUrls: ['./frontpage.component.scss']
})
export class FrontpageComponent implements OnInit {

  constructor(private route: Router) { }

  ngOnInit(): void {
  }

  userLogin(){
    this.route.navigate(['userLogin']);
  }

  
  userRegistration(){
    this.route.navigate(['userRegistration']);
  }
}
