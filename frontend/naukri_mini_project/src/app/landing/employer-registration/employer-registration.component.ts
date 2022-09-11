import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/core/services/data.service';
import { TokenService } from 'src/app/core/services/token.service';

@Component({
  selector: 'app-employer-registration',
  templateUrl: './employer-registration.component.html',
  styleUrls: ['./employer-registration.component.scss']
})
export class EmployerRegistrationComponent implements OnInit {

  employerRegistration: FormGroup = new FormGroup({});

  constructor(private router: Router, private data_service: DataService, private form: FormBuilder) { }

  ngOnInit(): void {

    this.employerRegistration = this.form.group({
      username: [''],
      password: [''],
      email: [''],
      companyName: [''],
      details: [''],
      phoneNumber: [''],
      alternatePhoneNumber: [''],
      category: ['']
    })
  }

  registerEmployer() {
    this.data_service.registerEmployer(this.employerRegistration.value).subscribe(registerEmployer => {
      alert("Registration Successful");
      this.router.navigate(['employerLogin'])
      console.log(this.employerRegistration.value);
    })
  }
}
