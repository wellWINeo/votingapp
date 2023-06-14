import { Component, Input } from '@angular/core';
import { ResultStatistic } from 'src/app/modules/api/models/results/result-statistic';

@Component({
  selector: 'statistic-item',
  templateUrl: './statistic-item.component.html',
  styleUrls: ['./statistic-item.component.scss'],
})
export class StatisticItemComponent {
  @Input() public set result(value: ResultStatistic) {
    this._result = value;
    this.statistics = value.statistics.map((s) => {
      return { name: s.displayText, value: s.count };
    });
  }

  public get result(): ResultStatistic {
    return this._result;
  }

  private _result!: ResultStatistic;

  public statistics: { name: string; value: number }[] = [];
}
