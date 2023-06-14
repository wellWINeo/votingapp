import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material.module';
import { ApiModule } from '../api/api.module';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { OptionsBuilderComponent } from './components/options-builder/options-builder.component';
import { JoinPipe } from './pipes/join.pipe';

const SHARED_MODULES: any[] = [
  HttpClientModule,
  FlexLayoutModule,
  CommonModule,
  ApiModule,
  MaterialModule,
  FormsModule,
  ReactiveFormsModule,
];

@NgModule({
  declarations: [OptionsBuilderComponent, JoinPipe],
  imports: [...SHARED_MODULES],
  exports: [...SHARED_MODULES, OptionsBuilderComponent, JoinPipe],
})
export class SharedModule {}
