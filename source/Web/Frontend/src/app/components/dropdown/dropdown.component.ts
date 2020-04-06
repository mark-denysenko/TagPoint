import { Component, Input, Output, EventEmitter, OnInit, forwardRef } from '@angular/core';
import { AppBaseComponent } from '../base/base.component';
import { NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.scss'],
  providers: [     
    {
      provide: NG_VALUE_ACCESSOR, 
      useExisting: forwardRef(() => AppDropdownComponent),
      multi: true     
    }   
  ]
})
export class AppDropdownComponent extends AppBaseComponent<any> implements OnInit {

  @Input() public options: any[] = [];
  @Input() public defaultText = '';
  @Input() public displayField: string | null = null;
  @Output() public changeOption = new EventEmitter<any>();

  public val: any;

  constructor() {
    super();
  }

  public change($event: any): void {
    this.value = this.options.find(o => 
      (this.displayField ? o[this.displayField] : o) === $event.target.value);
    this.changeOption.emit(this.value);
  }

  ngOnInit() {
  }

}
