import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExecutorListComponent } from './executor-list/executor-list.component';
import { ExecutorFormComponent } from './executor-form/executor-form.component';


const routes: Routes = [
  { path: 'executors', component: ExecutorListComponent },
  { path: 'executors/new', component: ExecutorFormComponent },
  { path: 'executors/:id', component: ExecutorFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExecutorRoutingModule { }
