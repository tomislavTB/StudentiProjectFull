import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChampionListComponent } from './champion-list/champion-list.component';
import { ChampionFormComponent } from './champion-form/champion-form.component';


const routes: Routes = [
  { path: 'champions', component: ChampionListComponent },
  { path: 'champions/new', component: ChampionFormComponent },
  { path: 'champions/:id', component: ChampionFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ChampionRoutingModule { }
