import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/core/services/data.service';
import { TokenService } from 'src/app/core/services/token.service';

@Component({
  selector: 'app-employer-login',
  templateUrl: './employer-login.component.html',
  styleUrls: ['./employer-login.component.scss']
})
export class EmployerLoginComponent implements OnInit {

  employer_form: FormGroup = new FormGroup({});

  constructor(private router: Router, private form_builder: FormBuilder, private data_service: DataService, private token: TokenService) { }

  ngOnInit(): void {

    this.employer_form = this.form_builder.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    })
  }

  employerRegistration() {
    this.router.navigate(['employerRegistration']);
  }

  employerLogin() {
    this.data_service.loginEmployer(this.employer_form.value).subscribe(login_employer => {
      if (login_employer) {
        alert("Employer Logged In");
        this.token.setToken(login_employer.token);
        this.router.navigate(['employerDashboard']);
      }
    },
      error => {
        alert("Invalid Employer Login Details");
      }
    )
  }

  get getFormControls(){
    return this.employer_form.controls;
  }
}
