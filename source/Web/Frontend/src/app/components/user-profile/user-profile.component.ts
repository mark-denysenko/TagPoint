import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
// import { Gender } from 'src/typing';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {

  @Input() user: any;
  @Input() isEditable: boolean = false;
  @Output() uploadAvatar = new EventEmitter<any>();

  constructor() { }

  ngOnInit() {
  }

  public handleUploadAvatar(files: any): void {
    if (files.length === 0) {
      return;
    }
 
    let fileToUpload = <File>files[0];
    this.uploadAvatar.emit(fileToUpload);
  }

  public getGender(gender: number): string {
    console.log('gender', gender);
    
    if (gender == 0) {
      return 'Чоловік';
    } else if (gender == 1) {
      return 'Жінка';
    } else {
      return '';
    }
  }

}
