import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/core/services/data.service';
import { TokenService } from 'src/app/core/services/token.service';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.scss']
})
export class JobsComponent implements OnInit {

  jobs: any = [];
  lakh_symbol = "LPA";
  rupee_symbol = "₹";

  constructor(private data: DataService, private token: TokenService, private route: Router) { }

  ngOnInit(): void {
    this.data.getJobs().subscribe(data => {
      this.jobs = data
    })
  }
}
