import { NgModule } from '@angular/core';
import { ApiModule } from '../api/api.module';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [],
  imports: [
    ApiModule,
    SharedModule,
    RouterModule.forChild([
      {
        path: 'create',
        loadChildren: () =>
          import('./modules/create-vote/create-vote.module').then(
            (m) => m.CreateVoteModule
          ),
      },
      {
        path: 'view',
        loadChildren: () =>
          import('./modules/vote-viewer/vote-viewer.module').then(
            (m) => m.VoteViewerModule
          ),
      },
      {
        path: 'list',
        loadChildren: () =>
          import('./modules/votes-list/vote-list.module').then(
            (m) => m.VoteListModule
          ),
      },
    ]),
  ],
  exports: [],
})
export class VotesModule {}
