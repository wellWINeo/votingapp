import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { VoteForm } from './models/vote.form';
import { Question } from './models/question';
import { VoteFormsService } from '../../../api/services/vote-forms.service';
import { firstValueFrom } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { QuestionValidator } from './validators/question.validator';

@Component({
  selector: 'vote-builder',
  templateUrl: './vote-builder.component.html',
  styleUrls: ['./vote-builder.component.scss'],
})
export class VoteBuilderComponent implements OnInit {
  public form = new FormGroup<VoteForm>({
    title: new FormControl<string>('', {
      nonNullable: true,
      validators: [Validators.required, Validators.minLength(1)],
    }),
    description: new FormControl<string | null>(null),
    accessMode: new FormControl<number>(0, {
      nonNullable: true,
      validators: [Validators.required],
    }),
    questions: new FormArray<FormControl<Question>>(
      [
        new FormControl<Question>(
          {
            text: '',
            isMultipleAllowed: false,
            isCustomAllowed: false,
            options: [],
          },
          { nonNullable: true, validators: [QuestionValidator] }
        ),
      ],
      { validators: [Validators.minLength(1)] }
    ),
  });

  public get questions(): FormArray<FormControl<Question>> {
    return this.form.get('questions') as FormArray<FormControl<Question>>;
  }

  constructor(
    private formsService: VoteFormsService,
    private snackBar: MatSnackBar,
    private router: Router
  ) {}

  ngOnInit(): void {}

  public addQuestion() {
    this.questions.push(
      new FormControl<Question>(
        {
          text: '',
          isMultipleAllowed: false,
          isCustomAllowed: false,
          options: [],
        },
        { nonNullable: true }
      )
    );
  }

  public removeQuestion(i: number) {
    this.questions.removeAt(i);
  }

  public async onSave(): Promise<void> {
    const payload = {
      title: this.form.value.title!,
      description: this.form.value.description!,
      accessMode: this.form.value.accessMode!,
      questions: this.form.value.questions!,
    };

    await firstValueFrom(this.formsService.create(payload));
    this.snackBar.open('Successfully saved', 'done', { duration: 2_000 });
    this.router.navigateByUrl('/');
  }
}
