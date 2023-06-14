import { FormArray, FormControl } from '@angular/forms';
import { Question } from './question';

export interface VoteForm {
  title: FormControl<string>;
  description: FormControl<string | null>;
  accessMode: FormControl<number>;
  questions: FormArray<FormControl<Question>>;
}
