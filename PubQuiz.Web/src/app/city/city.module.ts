import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CityRoutingModule } from './city-routing.module';
import { CityListComponent } from './city-list/city-list.component';
import { CityFormComponent } from './city-form/city-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbDatepickerModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';



@NgModule({
  declarations: [CityListComponent, CityFormComponent],
  imports: [
    CommonModule,
    CityRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    NgbDatepickerModule,
    NgxDatatableModule,
    NgbModule 
  ]
})
export class CityModule { }
