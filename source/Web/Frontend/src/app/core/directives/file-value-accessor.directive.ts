import { Directive, HostListener, Renderer2, ElementRef } from "@angular/core";
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from "@angular/forms";

@Directive({
  selector: 'input[type=file]',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: FileValueAccessorDirective,
      multi: true
    }
  ]
})
export class FileValueAccessorDirective implements ControlValueAccessor {
  private onChange: any;

  @HostListener('change', ['$event.target.value']) _handleInput(event: any) {
    this.onChange(event);
  }

  constructor(private element: ElementRef, private render: Renderer2) {  }

  writeValue(value: any) {
    const normalizedValue = value == null ? '' : value;
    this.render.setProperty(this.element.nativeElement, 'value', normalizedValue);
  }

  registerOnChange(fn: any) { this.onChange = fn; }

  registerOnTouched(_fn: any) {  }

  nOnDestroy() {  }
}
