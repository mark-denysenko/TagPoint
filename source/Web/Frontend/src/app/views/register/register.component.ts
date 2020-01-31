import { Component, OnInit } from '@angular/core';
import { AppUserService } from 'src/app/services/user.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class AppRegisterComponent implements OnInit {

  form = this.formBuilder.group({
    username: ["Username", Validators.required],
    login: ["admin", Validators.required],
    password: ["admin", Validators.required],
    email: ["admin@email.com", Validators.required],
    phone: ["", Validators.pattern('')],
    gender: [null, Validators.required],
    country: [null, Validators.required],

});

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly appUserService: AppUserService) { }

  ngOnInit() {
  }

  public register(): void {
    this.appUserService.register(this.form.value);
  }

}
