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
    login: ["admin", Validators.required],
    password: ["admin", Validators.required]
});

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly appUserService: AppUserService) { }

  ngOnInit() {
  }

  public register(): void {
    this.appUserService.signIn(this.form.value);
  }

}
