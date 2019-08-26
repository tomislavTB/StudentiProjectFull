import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeacherRoutingModule } from './teacher-routing.module';
import { TeacherListComponent } from './teacher-list/teacher-list.component';
import { TeacherFormComponent } from './teacher-form/teacher-form.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [TeacherListComponent, TeacherFormComponent],
  imports: [
    CommonModule,
    TeacherRoutingModule,
    FormsModule
  ]
})
export class TeacherModule { }
