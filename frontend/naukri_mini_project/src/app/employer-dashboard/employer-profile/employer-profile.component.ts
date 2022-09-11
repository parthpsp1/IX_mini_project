import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/core/services/data.service';

@Component({
  selector: 'app-employer-profile',
  templateUrl: './employer-profile.component.html',
  styleUrls: ['./employer-profile.component.scss']
})
export class EmployerProfileComponent implements OnInit {

  employer_profile: any = [];

  constructor(private data: DataService) { }

  ngOnInit(): void {
    this.data.getEmployer().subscribe(data =>{
      this.employer_profile = data;
      console.log(this.employer_profile);
    })
  }
}
