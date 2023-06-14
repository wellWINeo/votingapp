import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { VoteFormWithResult } from "../models/forms/vote-form-with-result";
import { VoteForm } from "../models/forms/vote-form";
import { CreateVoteFormRequest } from "../models/forms/create-vote-form.req";

@Injectable()
export class VoteFormsService {
  private readonly url: string = '/api/forms';

  constructor(private http: HttpClient) { }

  public create(req: CreateVoteFormRequest): Observable<any> {
    return this.http.post(`${this.url}/create`, req);
  }

  public getById(id: string): Observable<VoteFormWithResult> {
    return this.http.get<VoteFormWithResult>(`${this.url}/get-by-id/${id}`);
  }

  public getRecommends(): Observable<VoteForm[]> {
    return this.http.get<VoteForm[]>(`${this.url}/get-recommends`);
  }

  public getMy(): Observable<VoteForm[]> {
    return this.http.get<VoteForm[]>(`${this.url}/get-my`);
  }
}
