import { Component, OnInit } from '@angular/core';
import { Observable, map } from 'rxjs';
import { VoteResult } from 'src/app/modules/api/models/results/vote-result';
import { VoteResultsService } from 'src/app/modules/api/services/vote-results.service';

@Component({
  selector: 'vote-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss'],
})
export class VoteResultsComponent implements OnInit {
  public results$: Observable<VoteResult[]> = new Observable();

  constructor(private resultsService: VoteResultsService) {}

  ngOnInit(): void {
    this.results$ = this.resultsService.getMyResults();
  }
}
