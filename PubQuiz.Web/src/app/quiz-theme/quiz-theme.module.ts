import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { QuizThemeRoutingModule } from './quiz-theme-routing.module';
import { QuizThemeListComponent } from './quiz-theme-list/quiz-theme-list.component';
import { QuizThemeFormComponent } from './quiz-theme-form/quiz-theme-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbDatepickerModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';




@NgModule({
  declarations: [QuizThemeListComponent, QuizThemeFormComponent],
  imports: [
    CommonModule,
    QuizThemeRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbDatepickerModule,
    NgxDatatableModule,
    NgbModule 
  ]
})
export class QuizThemeModule { }
