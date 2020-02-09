import { Component, OnInit } from '@angular/core';
import { AppUserService } from 'src/app/services/user.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class AppRegisterComponent implements OnInit {

  public form = this.formBuilder.group({
    username: ["Username", Validators.required],
    signIn: this.formBuilder.group({
      login: ["admin", Validators.required],
      password: ["admin", Validators.required],
    }),
    email: ["admin@email.com", [Validators.required, Validators.email]],
    phone: ["", Validators.pattern('')],
    gender: [null, Validators.required],
    country: [null, Validators.required]
  });

  constructor(
    private readonly formBuilder: FormBuilder,
    //private readonly validationService: AppValidationService,
    private readonly appUserService: AppUserService) { }

  ngOnInit() {
  }

  public register(): void {
    this.appUserService.register({
      ...this.form.value,
      roles: 1 //Roles.User
    });
  }

}
