import { HttpClient } from '@angular/common/http';
import { AddResultRequest } from '../models/results/add-result-request';
import { Observable } from 'rxjs';
import { VoteResult } from '../models/results/vote-result';
import { Injectable } from '@angular/core';
import { ResultStatistics } from '../models/results/result-statistic';

@Injectable()
export class VoteResultsService {
  private readonly url: string = '/api/results';

  constructor(private http: HttpClient) {}

  public add(req: AddResultRequest): Observable<any> {
    return this.http.post(`${this.url}/add`, req);
  }

  public getMyResults(): Observable<VoteResult[]> {
    return this.http.get<VoteResult[]>(`${this.url}/my-results`);
  }

  public getResultStatistic(id: number): Observable<ResultStatistics> {
    return this.http.get<ResultStatistics>(`${this.url}/get-results/${id}`);
  }
}
