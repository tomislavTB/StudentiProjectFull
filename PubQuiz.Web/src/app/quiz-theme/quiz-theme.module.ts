import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { QuizThemeRoutingModule } from './quiz-theme-routing.module';
import { QuizThemeListComponent } from './quiz-theme-list/quiz-theme-list.component';
import { QuizThemeFormComponent } from './quiz-theme-form/quiz-theme-form.component';
import { FormsModule } from '@angular/forms';




@NgModule({
  declarations: [QuizThemeListComponent, QuizThemeFormComponent],
  imports: [
    CommonModule,
    QuizThemeRoutingModule,
    FormsModule
  ]
})
export class QuizThemeModule { }
