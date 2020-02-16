import { Component, OnInit } from '@angular/core';
import { AppBaseComponent } from '../base/base.component';

@Component({
  selector: 'app-textarea',
  templateUrl: './textarea.component.html',
  styleUrls: ['./textarea.component.scss']
})
export class TextareaComponent extends AppBaseComponent<any> implements OnInit {

  constructor() {
    super();
  }

  ngOnInit() {
  }

  input($event: any): void {
    this.value = $event.target.value;
  }

}
