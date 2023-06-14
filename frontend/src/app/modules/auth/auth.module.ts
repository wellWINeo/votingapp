import { NgModule } from '@angular/core';
import { MaterialModule } from 'src/app/material.module';
import { SharedModule } from '../shared/shared.module';
import { AuthService } from './auth.sevice';

@NgModule({
  imports: [
    MaterialModule,
    SharedModule,
  ],

  providers: [AuthService],
})
export class AuthModule {}
