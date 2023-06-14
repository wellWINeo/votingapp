import { Component, OnInit } from '@angular/core';
import { Observable, switchMap, map, tap } from 'rxjs';
import { ActivatedRoute, UrlSegment } from '@angular/router';
import { VoteForm } from 'src/app/modules/api/models/forms/vote-form';
import { VoteFormsService } from 'src/app/modules/api/services/vote-forms.service';

@Component({
  selector: 'all-votes',
  templateUrl: './all.component.html',
  styleUrls: ['./all.component.scss'],
})
export class AllVotesComponent implements OnInit {
  public votes$: Observable<VoteForm[]> = new Observable();
  public showAll: boolean = false;

  constructor(
    private formsService: VoteFormsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.votes$ = this.route.url.pipe(
      tap((url) => console.log(url)),
      map((url) => this.isShowAll(url)),
      tap((showAll) => (this.showAll = showAll)),
      switchMap((showAll) =>
        showAll ? this.formsService.getRecommends() : this.formsService.getMy()
      )
    );
  }

  private isShowAll(url: UrlSegment[]): boolean {
    return url[url.length - 1].path == 'all';
  }
}
