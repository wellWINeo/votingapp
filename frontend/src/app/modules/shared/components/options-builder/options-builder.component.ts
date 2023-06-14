import { Component, forwardRef } from '@angular/core';
import { CvaBase } from '../../cva.base';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { MatChipInputEvent } from '@angular/material/chips';

@Component({
  selector: 'options-builder',
  templateUrl: './options-builder.component.html',
  styleUrls: ['./options-builder.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => OptionsBuilderComponent),
      multi: true,
    },
  ],
})
export class OptionsBuilderComponent extends CvaBase<string[]> {
  public chips: string[] = [];

  override set value(val: string[]) {
    this.chips = val;
  }

  override get value(): string[] {
    return this.chips;
  }

  onRemove(toRemove: string) {
    this.chips = this.chips.filter((c) => c != toRemove);
    this.onTouchedCallback();
    this.onChangeCallback(this.chips);
  }

  public onAdd(event: MatChipInputEvent) {
    this.chips.push(event.value);
    event.chipInput.clear();
    this.onTouchedCallback();
    this.onChangeCallback(this.chips);
  }
}
