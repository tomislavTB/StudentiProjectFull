import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { QuizzesRoutingModule } from './quizzes-routing.module';
import { QuizzesFormComponent } from './quizzes-form/quizzes-form.component';
import { QuizzesListComponent } from './quizzes-list/quizzes-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { NgbDatepickerModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';


@NgModule({
  declarations: [QuizzesFormComponent, QuizzesListComponent],
  imports: [
    CommonModule,
    QuizzesRoutingModule,
    CKEditorModule,
    ReactiveFormsModule,
    NgbDatepickerModule,
    NgxDatatableModule,
    NgbModule 
  ],

  entryComponents: [
    QuizzesFormComponent
  ],
  exports: [QuizzesFormComponent]
})
export class QuizzesModule { }
