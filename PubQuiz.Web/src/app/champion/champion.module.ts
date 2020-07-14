import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChampionRoutingModule } from './champion-routing.module';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ChampionFormComponent } from './champion-form/champion-form.component';
import { ChampionListComponent } from './champion-list/champion-list.component';


@NgModule({
  declarations: [ChampionFormComponent, ChampionListComponent],
  imports: [
    CommonModule,
    ChampionRoutingModule,
    FormsModule,
    BrowserAnimationsModule
  ]
})
export class ChampionModule { }
