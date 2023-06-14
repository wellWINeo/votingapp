import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { authGuardFn } from '../auth/auth.guard';
import { ResultViewerComponent } from './modules/result-viewer/result-viewer.component';
import { ResultViewerModule } from './modules/result-viewer/result-viewer.module';

@NgModule({
  declarations: [],
  imports: [
    SharedModule,
    ResultViewerModule,
    RouterModule.forChild([
      {
        path: 'view/:id',
        canActivate: [authGuardFn],
        component: ResultViewerComponent,
      },
    ]),
  ],
  exports: [],
})
export class ResultsModule {}
