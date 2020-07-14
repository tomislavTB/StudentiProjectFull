import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CountryListComponent } from './country-list/country-list.component';
import { CountryFormComponent } from './country-form/country-form.component';


const routes: Routes = [
  { path: 'countries', component: CountryListComponent },
  { path: 'countries/new', component: CountryFormComponent },
  { path: 'countries/:id', component: CountryFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CountryRoutingModule { }
