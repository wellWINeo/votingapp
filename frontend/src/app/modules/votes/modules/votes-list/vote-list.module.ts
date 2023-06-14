import { NgModule } from '@angular/core';
import { AllVotesComponent } from './components/all/all.component';
import { VoteResultsComponent } from './components/results/results.component';
import { SharedModule } from 'src/app/modules/shared/shared.module';
import { ApiModule } from 'src/app/modules/api/api.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [AllVotesComponent, VoteResultsComponent],
  imports: [
    ApiModule,
    SharedModule,
    RouterModule.forChild([
      { path: 'all', component: AllVotesComponent },
      { path: 'my', component: AllVotesComponent },
      { path: 'results', component: VoteResultsComponent },
    ]),
  ],
  exports: [],
})
export class VoteListModule {}
