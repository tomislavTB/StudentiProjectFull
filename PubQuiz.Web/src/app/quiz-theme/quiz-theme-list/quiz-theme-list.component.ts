import { Component, OnInit } from '@angular/core';
import { QuizThemeService } from '../quiz-theme.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormService } from 'src/app/shared/form.service';

@Component({
  selector: 'app-quiz-theme-list',
  templateUrl: './quiz-theme-list.component.html',
  styleUrls: ['./quiz-theme-list.component.scss']
})
export class QuizThemeListComponent implements OnInit {

  constructor(private quizThemeService: QuizThemeService, private toastr: ToastrService, private router: Router, private form: FormService
    ) { }

    private quizThemes = [];

    ngOnInit() {
      this. getQuizThemes();
  }

    getQuizThemes()
     { this.quizThemeService.getAll().subscribe((response: any) => {
      this.quizThemes = response.response.data;
      console.log(this.quizThemes);
      
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

}
