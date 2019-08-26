import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CollegeRoutingModule } from './college-routing.module';
import { CollegeListComponent } from './college-list/college-list.component';
import { CollegeFormComponent } from './college-form/college-form.component';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [CollegeListComponent, CollegeFormComponent],
  imports: [
    CommonModule,
    CollegeRoutingModule,
    FormsModule,
    BrowserAnimationsModule
  ]
})
export class CollegeModule { }
