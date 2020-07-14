
import { Routes, RouterModule } from '@angular/router';
import { QuizzesListComponent } from './quizzes-list/quizzes-list.component';
import { QuizzesFormComponent } from './quizzes-form/quizzes-form.component';
import { NgModule } from '@angular/core';


const routes: Routes = [
  { path: 'quizzes', component: QuizzesListComponent },
  { path: 'quizzes/new', component: QuizzesFormComponent },
  { path: 'quizzes/:id', component: QuizzesFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuizzesRoutingModule { }
