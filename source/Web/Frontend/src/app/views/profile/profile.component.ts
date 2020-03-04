import { Component, OnInit } from '@angular/core';
import { AppUserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  public userProfile: any;

  constructor(private readonly appUserService: AppUserService) { }

  ngOnInit() {
    this.appUserService.getProfile().subscribe(profile => this.userProfile = profile);
  }

  public uploadAvatar(avatar: any): void {
    this.appUserService.uploadAvatar(avatar).subscribe(profile => this.userProfile = profile);
  }

}
