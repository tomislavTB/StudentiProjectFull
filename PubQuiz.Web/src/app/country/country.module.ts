import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CountryRoutingModule } from './country-routing.module';
import { CountryListComponent } from './country-list/country-list.component';
import { CountryFormComponent } from './country-form/country-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgbDatepickerModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';



@NgModule({
  declarations: [CountryListComponent, CountryFormComponent],
  imports: [
    CommonModule,
    CountryRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbDatepickerModule,
    NgxDatatableModule,
    NgbModule
  ]
})
export class CountryModule { }
