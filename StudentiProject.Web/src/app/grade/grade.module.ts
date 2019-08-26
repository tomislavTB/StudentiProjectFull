import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GradeRoutingModule } from './grade-routing.module';
import { GradeListComponent } from './grade-list/grade-list.component';
import { GradeFormComponent } from './grade-form/grade-form.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [GradeListComponent, GradeFormComponent],
  imports: [
    CommonModule,
    GradeRoutingModule,
    FormsModule
  ]
})
export class GradeModule { }
