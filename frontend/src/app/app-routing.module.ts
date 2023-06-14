import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuardFn } from './modules/auth/auth.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/votes/list/all',
    pathMatch: 'full',
  },
  {
    path: 'auth',
    loadChildren: () =>
      import('./modules/auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: 'votes',
    canActivate: [authGuardFn],
    loadChildren: () =>
      import('./modules/votes/votes.module').then((m) => m.VotesModule),
  },
  {
    path: 'results',
    loadChildren: () =>
      import('./modules/results/results.module').then((m) => m.ResultsModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
