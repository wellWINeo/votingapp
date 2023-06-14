import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UntilDestroy } from '@ngneat/until-destroy';
import { Observable, filter, map, switchMap } from 'rxjs';
import { ResultStatistics } from 'src/app/modules/api/models/results/result-statistic';
import { VoteResultsService } from 'src/app/modules/api/services/vote-results.service';

@Component({
  selector: 'result-viewer',
  templateUrl: './result-viewer.component.html',
  styleUrls: ['./result-viewer.component.scss'],
})
@UntilDestroy()
export class ResultViewerComponent implements OnInit {
  public statistics$: Observable<ResultStatistics> = new Observable();

  constructor(
    private route: ActivatedRoute,
    private resultsService: VoteResultsService
  ) {}

  ngOnInit(): void {
    this.statistics$ = this.route.params.pipe(
      map((p) => p['id']),
      filter((id) => !!id),
      switchMap((id) => this.resultsService.getResultStatistic(id))
    );
  }
}
