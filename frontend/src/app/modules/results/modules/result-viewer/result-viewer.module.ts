import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { ResultViewerComponent } from './result-viewer.component';
import { RouterModule } from '@angular/router';
import { authGuardFn } from '../../../auth/auth.guard';
import { StatisticItemComponent } from './components/statistic-item/statistic-item.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';

@NgModule({
  declarations: [ResultViewerComponent, StatisticItemComponent],
  imports: [
    SharedModule,
    NgxChartsModule,
    RouterModule.forChild([
      {
        path: 'view/:id',
        canActivate: [authGuardFn],
        component: ResultViewerComponent,
      },
    ]),
  ],
  exports: [ResultViewerComponent],
})
export class ResultViewerModule {}
