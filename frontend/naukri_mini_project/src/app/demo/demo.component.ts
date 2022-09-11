import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from '../core/services/data.service';

@Component({
  selector: 'app-demo',
  templateUrl: './demo.component.html',
  styleUrls: ['./demo.component.scss']
})
export class DemoComponent implements OnInit {

  user_form: FormGroup = new FormGroup({});
  employer_form: FormGroup = new FormGroup({});
  job_form: FormGroup = new FormGroup({});

  constructor(private routelink: Router, private data_service: DataService, private form_builder: FormBuilder) { }

  ngOnInit(): void {

    this.user_form = this.form_builder.group({
      FirstName: [''],
      LastName: [''],
      Email: [''],
      Password: [''],
      MobileNumber: [''],
      AlternateMobileNumber: [''],
      TenthPercentage: [''],
      TwelthPercentage: [''],
      DiplomaPercentage: [''],
      BachlorsPercentage: [''],
      MastersPercentage: [''],
      DoctoratePhDPercentage: [''],
      WorkStatus: [true],
      Certification: [''],
      // Resume:['']
    });

    this.employer_form = this.form_builder.group({
      CompanyName: [''],
      Details: [''],
      Email: [''],
      Password: [''],
      MobileNumber: [''],
      AlternateMobileNumber: [''],
      Category: ['']
    })

    this.job_form = this.form_builder.group({
      Title: [''],
      Address: [''],
      Description: [''],
      PayRange: [''],
      PersonOfContact: [''],
      Visiblity: ['']

    })

    this.data_service.getUser().subscribe(val => {
      console.log(val);
    });
  }

  addUser() {
    this.data_service.addUser(this.user_form.value).subscribe(add_user => {
      console.log("Inside User Add Function");
      console.log(this.user_form.value);
    })
  }

  addEmployer() {
    this.data_service.addEmployer(this.employer_form.value).subscribe(add_employer => {
      console.log("Inside Employer Add Function");
      console.log(this.employer_form.value);
    })
  }

  addJob() {
    this.data_service.addjob(this.job_form.value).subscribe(add_job => {
      console.log("Inside Job Add Function");
      console.log(this.job_form.value);
    })
  }

  message() {
    alert("Logged In");
    this.routelink.navigate(['']);
  }

  loginFormDetails() {
    this.data_service.getUser().subscribe(val => {
      console.log(val);
    });
  }
}
