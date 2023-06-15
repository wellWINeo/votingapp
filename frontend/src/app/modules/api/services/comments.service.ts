import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { VoteFormComment } from '../models/comments/vote-form-comment';
import { OAuthService } from 'angular-oauth2-oidc';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class CommentsService {
  public comments$ = new BehaviorSubject<VoteFormComment[]>([]);
  public get comments(): VoteFormComment[] {
    return this.comments$.getValue();
  }

  private connection!: HubConnection | null;

  constructor(private authService: OAuthService) {}

  public async start(): Promise<void> {
    this.connection = new HubConnectionBuilder()
      .withAutomaticReconnect()
      .withUrl(environment.hubUrl, {
        accessTokenFactory: () => this.authService.getAccessToken(),
      })
      .build();

    this.connection.on('commentAdded', (comment) => this.push([comment]));

    await this.connection.start();
  }

  private push(comments: VoteFormComment[]) {
    const updatedComments = [...this.comments, ...comments];
    this.comments$.next(updatedComments);
  }

  public dispose() {
    this.connection?.stop();
  }

  public formOpened(id: string) {
    this.connection?.send('formOpened', id);
  }

  public formClosed(id: string) {
    this.connection?.send('formClosed', id);
  }

  public addComment(comment: string, id: string) {
    this.connection?.send('addComment', { comment: comment, formId: id });
  }

  public async loadComments(id: string) {
    const comments = await this.connection?.invoke<VoteFormComment[]>(
      'getComments',
      id
    );

    this.comments$.next(comments ?? []);
  }
}
