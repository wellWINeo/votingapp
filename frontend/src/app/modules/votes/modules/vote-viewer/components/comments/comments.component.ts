import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { VoteFormComment } from 'src/app/modules/api/models/comments/vote-form-comment';
import { CommentsService } from 'src/app/modules/api/services/comments.service';

@Component({
  selector: 'comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.scss'],
})
export class CommentsComponent implements OnInit, OnDestroy {
  @Input() formId!: string;

  public comment: string = '';

  public get comments$(): Observable<VoteFormComment[]> {
    return this.commentsService.comments$;
  }

  constructor(private commentsService: CommentsService) {}

  ngOnInit(): void {
    this.commentsService.loadComments(this.formId);
    this.commentsService.formOpened(this.formId);
  }

  ngOnDestroy(): void {
    this.commentsService.formClosed(this.formId);
  }

  public send() {
    this.commentsService.addComment(this.comment, this.formId);
  }
}
