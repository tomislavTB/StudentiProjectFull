import { Component, OnInit } from '@angular/core';
import { QuizThemeService } from '../quiz-theme.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormService } from 'src/app/shared/form.service';
import { NgxDatatablePageLimitEnum } from 'src/app/shared/ngx-datatable-page-limit.enum';

@Component({
  selector: 'app-quiz-theme-list',
  templateUrl: './quiz-theme-list.component.html',
  styleUrls: ['./quiz-theme-list.component.scss']
})
export class QuizThemeListComponent implements OnInit {

  constructor(private quizThemeService: QuizThemeService, private toastr: ToastrService, private router: Router, private form: FormService
    ) { }
    login: any;
    private quizThemes = [];

    ngOnInit() {
      this. getQuizThemes();
      this.login = localStorage.getItem('auth_user')
  }

    getQuizThemes()
     { this.quizThemeService.getAll().subscribe((response: any) => {
      this.quizThemes = response.response.data;
      
  });
}

  onDelete(quizThemeId) {
    if (confirm('Da li ste sigurni?')) {
      this.quizThemeService.deleteOne(quizThemeId).subscribe(result => {
        this.quizThemeService.getAll();
        this.toastr.success('Izbrisali ste kolegij.');
        this. getQuizThemes();
   });
 }
}

onAdd() {
   this.router.navigate(['quizThemes/new']);
}

onEdit(quizThemeId) {
  this.form.show();
  this.router.navigate(['quizThemes', quizThemeId]);
}
get pageLimit() {
  return NgxDatatablePageLimitEnum.limit;
}
}
