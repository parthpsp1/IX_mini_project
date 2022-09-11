import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/core/services/data.service';

@Component({
  selector: 'app-create-job',
  templateUrl: './create-job.component.html',
  styleUrls: ['./create-job.component.scss']
})
export class CreateJobComponent implements OnInit {

  job_form: FormGroup = new FormGroup({});

  constructor(private routelink: Router, private data_service: DataService, private form_builder: FormBuilder) { }

  ngOnInit(): void {

    this.job_form = this.form_builder.group({
      employerID: [1],
      title: [''],
      description: [''],
      address: [''],
      payRange: [''],
      personOfContact: [''],
    })
  }

  addJob() {
    this.data_service.addjob(this.job_form.value).subscribe(add_job => {
    })
    alert("Job Added");
  }
}
