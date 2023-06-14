import { Component, OnInit, forwardRef } from '@angular/core';
import {
  ControlValueAccessor,
  FormControl,
  FormGroup,
  NG_VALUE_ACCESSOR,
  Validators,
} from '@angular/forms';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { CvaBase } from 'src/app/modules/shared/cva.base';
import { Question } from '../../models/question';
import { QuestionForm } from '../../models/question.form';

@Component({
  selector: 'question-builder',
  templateUrl: './question-builder.component.html',
  styleUrls: ['./question-builder.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => QuestionBuilder),
      multi: true,
    },
  ],
})
@UntilDestroy()
export class QuestionBuilder
  extends CvaBase<Question>
  implements OnInit, ControlValueAccessor
{
  public form = new FormGroup<QuestionForm>({
    text: new FormControl<string>('', {
      nonNullable: true,
      validators: [Validators.required, Validators.minLength(1)],
    }),
    options: new FormControl<string[]>([], { nonNullable: true }),
    isMultipleAllowed: new FormControl<boolean>(false, { nonNullable: true }),
    isCustomAllowed: new FormControl<boolean>(false, { nonNullable: true }),
  });

  override set value(val: Question) {
    this.form.setValue(val);
  }

  override get value(): Question {
    return <Question>this.form.value;
  }

  ngOnInit(): void {
    this.form.valueChanges.pipe(untilDestroyed(this)).subscribe((value) => {
      this.onTouchedCallback();
      this.onChangeCallback(<Question>value);
    });
  }
}
