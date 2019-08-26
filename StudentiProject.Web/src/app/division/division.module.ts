import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DivisionRoutingModule } from './division-routing.module';
import { DivisionListComponent } from './division-list/division-list.component';
import { DivisionFormComponent } from './division-form/division-form.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [DivisionListComponent, DivisionFormComponent],
  imports: [
    CommonModule,
    DivisionRoutingModule,
    FormsModule
  ]
})
export class DivisionModule { }
