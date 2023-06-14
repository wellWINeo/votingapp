import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from './modules/auth/auth.sevice';
import { CommentsService } from './modules/api/services/comments.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'frontend';

  constructor(
    private authService: AuthService,
    private commentsService: CommentsService
  ) {}

  async ngOnInit(): Promise<void> {
    this.authService.setup();
    this.commentsService.start();
  }

  ngOnDestroy(): void {
    this.commentsService.dispose();
  }
}
