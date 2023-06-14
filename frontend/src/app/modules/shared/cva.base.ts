import { ControlValueAccessor } from "@angular/forms";

export abstract class CvaBase<T> implements ControlValueAccessor {

  protected onChangeCallback: (obj: T) => void = _ => { };
  protected onTouchedCallback: () => void = () => { };

  abstract set value(val: T);
  abstract get value(): T;


  writeValue(obj: T): void {
    this.value = obj;
  }

  registerOnChange(fn: any): void {
    this.onChangeCallback = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouchedCallback = fn;
  }

  setDisabledState?(isDisabled: boolean): void { }
}
