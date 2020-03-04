import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

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

}
