import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExecutorRoutingModule } from './executor-routing.module';
import { ExecutorListComponent } from './executor-list/executor-list.component';
import { ExecutorFormComponent } from './executor-form/executor-form.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [ExecutorListComponent, ExecutorFormComponent],
  imports: [
    CommonModule,
    ExecutorRoutingModule,
    FormsModule
  ]
})
export class ExecutorModule { }
