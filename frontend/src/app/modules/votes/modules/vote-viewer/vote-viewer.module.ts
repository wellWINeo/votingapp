import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { VoteViewerComponent } from './vote-viewer.component';
import { QuestionComponent } from './components/question/question.component';
import { CommentsComponent } from './components/comments/comments.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [VoteViewerComponent, QuestionComponent, CommentsComponent],
  imports: [
    SharedModule,
    RouterModule.forChild([{ path: ':id', component: VoteViewerComponent }]),
  ],
  exports: [VoteViewerComponent],
})
export class VoteViewerModule {}
