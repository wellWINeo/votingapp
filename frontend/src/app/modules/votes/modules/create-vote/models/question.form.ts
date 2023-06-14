import { FormControl } from '@angular/forms';

export interface QuestionForm {
  text: FormControl<string>;
  options: FormControl<string[]>;
  isMultipleAllowed: FormControl<boolean>;
  isCustomAllowed: FormControl<boolean>;
}
