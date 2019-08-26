import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CollegeListComponent } from './college-list/college-list.component';
import { CollegeFormComponent } from './college-form/college-form.component';


const routes: Routes = [
  { path: 'colleges', component: CollegeListComponent },
  { path: 'colleges/new', component: CollegeFormComponent },
  { path: 'colleges/:id', component: CollegeFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CollegeRoutingModule { }
