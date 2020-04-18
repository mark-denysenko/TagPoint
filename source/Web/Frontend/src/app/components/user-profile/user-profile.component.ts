import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { AppUserService } from 'src/app/services/user.service';
import { AppModalService } from 'src/app/core/services/modal.service';
import { Country } from 'src/typing';
import { GeolocationService } from 'src/app/services/geolocation.service';
// import { Gender } from 'src/typing';

declare let UIkit: any;

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

  public countries: Country[] = [];
  public genders: any[] = [{ gender: 'Чоловік', value: 0 }, { gender: 'Жінка', value: 1 }];

  public get dropdownCountries(): string[] {
    return this.countries.map(c => c.country);
  }

  public get dropdownGenders(): string[] {
    return this.genders.map(c => c.gender);
  }

  constructor(private readonly formBuilder: FormBuilder,
    private readonly appUserService: AppUserService, 
    private readonly modalService: AppModalService,
    private readonly geolocationService: GeolocationService) { }

  ngOnChanges(changes: SimpleChanges): void {
    if(changes.user){
      const newValue = changes.user.currentValue;
      this.userForm.patchValue({ ...newValue, gender: this.getGender(newValue.gender)}, { emitEvent: false });
      this.userForm.markAsPristine();
    }
  }

  ngOnInit() {
    this.geolocationService.getCountries().subscribe(res => this.countries = res);
  }

  public handleUploadAvatar(files: any): void {
    if (files.length === 0) {
      return;
    }
 
    let fileToUpload = <File>files[0];
    this.uploadAvatar.emit(fileToUpload);
  }

  public getGender(gender: number): string {
    const _gender = this.genders.find(g => g.value == gender);
    return _gender ? _gender.gender : '';
  }

  public saveChanges(): void {
    var updatedUser = {...this.user, ...this.userForm.value };
    this.appUserService.update({ 
      ...updatedUser,
      countryId: this.countries.find(c => c.country === updatedUser.country)!.id,
      gender: this.genders.find(g => g.gender === updatedUser.gender).value
     }).subscribe(_ => this.modalService.successfullySavedNotification());
  }

  public changePassword(): void {
    const { oldPassword, newPassword } = this.changePasswordForm.value;

    this.appUserService.changePassword(this.user.id, oldPassword, newPassword)
      .subscribe(_ => this.modalService.successfullySavedNotification());
  }

}
