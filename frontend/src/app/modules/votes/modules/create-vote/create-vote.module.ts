import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { VoteBuilderComponent } from './vote-builder.component';
import { RouterModule } from '@angular/router';
import { QuestionBuilder } from './components/question-builder/question-builder.component';
import { AccessModeSelectorComponent } from './components/access-mode-selector/access-mode-selector.component';

@NgModule({
  declarations: [QuestionBuilder, VoteBuilderComponent, AccessModeSelectorComponent],

  imports: [
    SharedModule,
    RouterModule.forChild([
      {
        path: '',
        component: VoteBuilderComponent,
      },
    ]),
  ],

  exports: [VoteBuilderComponent],
})
export class CreateVoteModule {}
