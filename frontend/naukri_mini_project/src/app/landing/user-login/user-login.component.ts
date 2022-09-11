import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/core/services/data.service';
import { TokenService } from 'src/app/core/services/token.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent implements OnInit {

  user_form: FormGroup = new FormGroup({});

  constructor(private data_service: DataService, private form_builder: FormBuilder, private router: Router, private token: TokenService) { }

  ngOnInit(): void {

    this.user_form = this.form_builder.group({
      username: ['',[Validators.required]],
      password: ['',[Validators.required]],
    });
  }

  userRegistration() {
    this.router.navigate(['userRegistration']);
  }

  userLogin() {
    this.data_service.loginUser(this.user_form.value).subscribe(login_user => {
      if (login_user) {
        alert("User Logged In");
        this.token.setToken(login_user.token);
        this.router.navigate(['home/jobs']);
      }
    },
      error => {
        alert("Invalid User Login Details");
      }
    );
  }

  get FormControls(){
    return this.user_form.controls;
  }
}
