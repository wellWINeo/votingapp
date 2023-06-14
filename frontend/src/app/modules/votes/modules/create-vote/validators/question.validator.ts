import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Question } from '../models/question';

export const QuestionValidator: ValidatorFn = (
  control: AbstractControl
): ValidationErrors | null => {
  const errors: ValidationErrors = {};
  const value: Question = control.value;

  if (!value.text) errors['emptyText'] = true;
  if (value.options.length < 2) errors['emptyOptions'] = true;

  return Object.keys(errors).length != 0 ? errors : null;
};
