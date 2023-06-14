import { Observable } from 'rxjs';
import { AccessMode } from '../models/access-modes/access-mode';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class AccessModesService {
  private readonly url: string = '/api/access-modes';

  constructor(private http: HttpClient) {}

  public get(): Observable<AccessMode[]> {
    return this.http.get<AccessMode[]>(`${this.url}/get`);
  }
}
