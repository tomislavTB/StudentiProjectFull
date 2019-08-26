import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GradeListComponent } from './grade-list/grade-list.component';
import { GradeFormComponent } from './grade-form/grade-form.component';


const routes: Routes = [
  { path: 'grades', component: GradeListComponent },
  { path: 'grades/new', component: GradeFormComponent },
  { path: 'grades/:id', component: GradeFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GradeRoutingModule { }
