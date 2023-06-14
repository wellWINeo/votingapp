import { NgModule } from '@angular/core';
import { VoteFormsService } from './services/vote-forms.service';
import { VoteResultsService } from './services/vote-results.service';
import { AccessModesService } from './services/access-modes.service';

@NgModule({
  providers: [VoteFormsService, VoteResultsService, AccessModesService],
})
export class ApiModule {}
