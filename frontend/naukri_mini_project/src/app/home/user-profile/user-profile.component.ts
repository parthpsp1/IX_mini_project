import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { DataService } from 'src/app/core/services/data.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {

  user_profile: any = [];
  percentangeSymbol ="%";

  constructor(private data: DataService) { }

  ngOnInit(): void {
    this.data.getUser().subscribe(data => {
      this.user_profile = data;
      console.log(this.user_profile);
    })
  }
}
