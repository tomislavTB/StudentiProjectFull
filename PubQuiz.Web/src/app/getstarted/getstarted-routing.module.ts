import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GetstartedListComponent } from './getstarted-list/getstarted-list.component';


const routes: Routes = [
  { path: 'getstarted', component: GetstartedListComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GetstartedRoutingModule { }
