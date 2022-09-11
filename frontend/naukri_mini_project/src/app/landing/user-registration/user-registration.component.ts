import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/core/services/data.service';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.scss']
})
export class UserRegistrationComponent implements OnInit {

  user_registration_form: FormGroup = new FormGroup({});

  constructor(private router: Router, private form: FormBuilder, private data: DataService) { }

  ngOnInit(): void {

    this.user_registration_form = this.form.group({
      username: ['',
      [
        Validators.required, 
        Validators.minLength(2),
        Validators.maxLength(10)
      ]],
      email: ['',
      [
        Validators.required,
        Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")
      ]],
      password: [''],
      firstName: ['',
      [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(10),
        Validators.pattern("[a-zA-Z]+$")
      ]],
      lastName: ['',
      [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(10),
        Validators.pattern("[a-zA-Z]+$")
      ]],
      phoneNumber: ['',
      [
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(10),
        Validators.pattern("^[0-9]*$")
      ]],
      alternatePhoneNumber: ['',
      [
        Validators.minLength(10),
        Validators.maxLength(10),
        Validators.pattern("^[0-9]*$")
      ]],
      tenthPercentage: ['',
      [
        Validators.maxLength(2),
        Validators.pattern("^[0-9]*$")
      ]],
      twelthPercentage: ['',
      [
        Validators.maxLength(2),
        Validators.pattern("^[0-9]*$")
      ]],
      diplomaPercentage: ['',
      [
        Validators.maxLength(2),
        Validators.pattern("^[0-9]*$")
      ]],
      bachlorsPercentage: ['',[
        Validators.maxLength(2),
        Validators.pattern("^[0-9]*$")
      ]],
      mastersPercentage: ['',[
        Validators.maxLength(2),
        Validators.pattern("^[0-9]*$")
      ]],
      doctoratePhDPercentage: ['',[
        Validators.maxLength(2),
        Validators.pattern("^[0-9]*$")
      ]],
      certification: ['']
    })
  }

  
  get formControls() {
    return this.user_registration_form.controls;
  }

  userLogin() {
    this.data.registerUser(this.user_registration_form.value).subscribe(registerUser => {
      alert("Registration Successful");
      this.router.navigate(['userLogin'])
      console.log(this.user_registration_form.value);
    })
  }
}
