import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { Observable, firstValueFrom, map, switchMap, tap } from 'rxjs';
import { VoteFormsService } from '../../../api/services/vote-forms.service';
import { VoteFormWithResult } from '../../../api/models/forms/vote-form-with-result';
import { FormArray, FormControl } from '@angular/forms';
import { QuestionResult } from './models/question-result';
import { AddResultRequest } from '../../../api/models/results/add-result-request';
import { VoteResultsService } from '../../../api/services/vote-results.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { QuestionResultValidator } from './validators/question-result.validator';

@Component({
  selector: 'vote-viewer',
  templateUrl: './vote-viewer.component.html',
  styleUrls: ['./vote-viewer.component.scss'],
})
@UntilDestroy()
export class VoteViewerComponent implements OnInit {
  public vote$: Observable<VoteFormWithResult> = new Observable();

  public questions = new FormArray<FormControl<QuestionResult>>([]);

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar,
    private formsService: VoteFormsService,
    private resultsService: VoteResultsService
  ) {}

  ngOnInit(): void {
    this.vote$ = this.route.params.pipe(
      untilDestroyed(this),
      map((p) => p['id']),
      switchMap((id: string) => this.formsService.getById(id)),
      tap((vote) => (this.questions = this.getQuestionsArray(vote))),
      tap((_) => console.log(this.questions))
    );
  }

  private getQuestionsArray(
    vote: VoteFormWithResult
  ): FormArray<FormControl<QuestionResult>> {
    const controls = vote.questions.map(
      (q) =>
        new FormControl<QuestionResult>(
          {
            questionId: q.questionId,
            values: q.selectedOptions?.map((sv) => sv.id) ?? [],
          },
          { nonNullable: true, validators: [QuestionResultValidator] }
        )
    );

    const formArray = new FormArray<FormControl<QuestionResult>>(controls);

    if (vote.isVoted) formArray.disable();

    return formArray;
  }

  public getControl(
    questionId: string
  ): FormControl<QuestionResult> | undefined {
    return this.questions.controls.find(
      (c) => c.value.questionId == questionId
    );
  }

  public async onVote(formId: string) {
    const payload: AddResultRequest = {
      formId: formId,
      questions: this.questions.value,
    };

    await firstValueFrom(this.resultsService.add(payload));
    this.snackBar.open("You're voted!", 'done', { duration: 2000 });
    this.router.navigate(['']);
  }
}
