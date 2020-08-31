import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChampionRoutingModule } from './champion-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ChampionFormComponent } from './champion-form/champion-form.component';
import { ChampionListComponent } from './champion-list/champion-list.component';
import { NgbDatepickerModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';


@NgModule({
  declarations: [ChampionFormComponent, ChampionListComponent],
  imports: [
    CommonModule,
    ChampionRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    NgbDatepickerModule,
    NgxDatatableModule,
    NgbModule 
  ],
  entryComponents: [
    ChampionFormComponent
  ],
})
export class ChampionModule { }
