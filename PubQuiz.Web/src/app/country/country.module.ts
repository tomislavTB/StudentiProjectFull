import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CountryRoutingModule } from './country-routing.module';
import { CountryListComponent } from './country-list/country-list.component';
import { CountryFormComponent } from './country-form/country-form.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [CountryListComponent, CountryFormComponent],
  imports: [
    CommonModule,
    CountryRoutingModule,
    FormsModule
  ]
})
export class CountryModule { }
