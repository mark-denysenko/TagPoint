import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-post-creator',
  templateUrl: './post-creator.component.html',
  styleUrls: ['./post-creator.component.scss']
})
export class PostCreatorComponent implements OnInit {

  public text: FormControl;

  @Output() sendPost = new EventEmitter<string>();

  constructor() {
    this.text = new FormControl('', [Validators.required, Validators.maxLength(1000)]);
  }

  ngOnInit() {
  }

  public handleSendPost(): void {
    this.sendPost.emit(this.text.value);
  }

}
