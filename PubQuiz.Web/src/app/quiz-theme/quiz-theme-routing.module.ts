import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { QuizThemeListComponent } from './quiz-theme-list/quiz-theme-list.component';
import { QuizThemeFormComponent } from './quiz-theme-form/quiz-theme-form.component';


const routes: Routes = [
  { path: 'quizThemes', component: QuizThemeListComponent },
  { path: 'quizThemes/new', component: QuizThemeFormComponent },
  { path: 'quizThemes/:id', component: QuizThemeFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuizThemeRoutingModule { }
