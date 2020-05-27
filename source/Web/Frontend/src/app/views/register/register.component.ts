import { Component, OnInit } from '@angular/core';
import { AppUserService } from 'src/app/services/user.service';
import { FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { GeolocationService } from 'src/app/services/geolocation.service';
import { Country } from 'src/typing';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class AppRegisterComponent implements OnInit {

  public form = this.formBuilder.group({
    username: ["", Validators.required],
    signIn: this.formBuilder.group({
      login: ["", Validators.required],
      password: ["", Validators.required],
    }),
    email: ["", [Validators.required, Validators.email]],
    phone: ["", Validators.pattern('')],
    gender: [null, Validators.required],
    country: [null, Validators.required]
  });

  public countries: Country[] = [];
  public genders: any[] = [{ gender: 'Чоловік', value: 0 }, { gender: 'Жінка', value: 1 }];

  public get dropdownCountries(): string[] {
    return this.countries.map(c => c.country);
  }

  public get dropdownGenders(): string[] {
    return this.genders.map(c => c.gender);
  }

  constructor(
    private readonly formBuilder: FormBuilder,
    //private readonly validationService: AppValidationService,
    private readonly appUserService: AppUserService,
    private readonly geolocationService: GeolocationService) { }

  ngOnInit() {
    this.geolocationService.getCountries().subscribe(res => this.countries = res);
  }

  public register(): void {
    const genderControl = this.form.get('gender') as AbstractControl;
    const countryControl = this.form.get('country') as AbstractControl;

    const gender = this.genders.find(g => g.gender === genderControl.value).value;
    const country = this.countries.find(c => c.country === countryControl.value);

    const mappedForm = {
      ...this.form.value,
      gender,
      countryId: !!country ? country.id : null
    };

    this.appUserService.register(mappedForm);
  }

}
