import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
// import { Gender } from 'src/typing';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit, OnChanges {

  @Input() user: any;
  @Input() isEditable: boolean = false;
  @Output() uploadAvatar = new EventEmitter<any>();

  public userForm = this.formBuilder.group({
    username: [null, Validators.required],
    email: [null, [Validators.required, Validators.email]],
    phone: [null, Validators.pattern('')],
    gender: [null, Validators.required],
    country: [null, Validators.required]
  });

  public changePasswordForm = this.formBuilder.group({
    oldPassword: [null, Validators.required],
    newPassword: [null, Validators.required]
  });

  constructor(private readonly formBuilder: FormBuilder) { }

  ngOnChanges(changes: SimpleChanges): void {
    if(changes.user){
      this.userForm.patchValue({ ...changes.user.currentValue});
    }
  }

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
    if (gender == 0) {
      return 'Чоловік';
    } else if (gender == 1) {
      return 'Жінка';
    } else {
      return '';
    }
  }

  public saveChanges(): void {

  }

  public changePassword(): void {
    
  }

}
