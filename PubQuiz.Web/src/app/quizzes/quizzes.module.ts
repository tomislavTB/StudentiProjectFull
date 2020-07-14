import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { QuizzesRoutingModule } from './quizzes-routing.module';
import { QuizzesFormComponent } from './quizzes-form/quizzes-form.component';
import { QuizzesListComponent } from './quizzes-list/quizzes-list.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [QuizzesFormComponent, QuizzesListComponent],
  imports: [
    CommonModule,
    QuizzesRoutingModule,
    FormsModule
  ]
})
export class QuizzesModule { }
