import { Component, Input, forwardRef } from '@angular/core';
import { Option } from '../../models/option';
import { CvaBase } from 'src/app/modules/shared/cva.base';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { QuestionResult } from '../../models/question-result';

@Component({
  selector: 'question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => QuestionComponent),
      multi: true,
    },
  ],
})
export class QuestionComponent extends CvaBase<QuestionResult> {
  @Input() public questionId!: string;
  @Input() public text: string = '';
  @Input() public multiple: boolean = false;
  @Input() public options: Option[] = [];

  public selectedValue: string | null = null;
  public selectedMultipleValues: string[] = [];

  public disabled: boolean = false;

  override set value(val: QuestionResult) {
    if (!val.values.length) return;

    if (this.multiple) {
      this.selectedMultipleValues = val.values;
      return;
    }

    this.selectedValue = val.values[0];
  }
  override get value(): QuestionResult {
    return {
      questionId: this.questionId,
      values: this.multiple
        ? this.selectedMultipleValues
        : [this.selectedValue!],
    };
  }

  public isChecked(id: string): boolean {
    return this.selectedMultipleValues.includes(id);
  }

  public onCheckboxChange(event: MatCheckboxChange) {
    if (event.checked) {
      this.selectedMultipleValues.push(event.source.value);
    } else {
      this.selectedMultipleValues = this.selectedMultipleValues.filter(
        (s) => s != event.source.value
      );
    }
    this.onTouchedCallback();
    this.onChangeCallback(this.value);
  }

  public onSingleChoiceChange() {
    this.onTouchedCallback();
    this.onChangeCallback(this.value);
  }

  override setDisabledState(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }
}
