import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { QuestionResult } from '../models/question-result';

export const QuestionResultValidator: ValidatorFn = (
  control: AbstractControl
): ValidationErrors | null => {
  return (<QuestionResult>control.value).values.length == 0 ? { notSelected: true } : null;
};
