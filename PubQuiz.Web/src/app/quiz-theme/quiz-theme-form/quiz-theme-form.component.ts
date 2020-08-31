import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { QuizThemeService } from '../quiz-theme.service';
import { ToastrService } from 'ngx-toastr';
import { FormService } from 'src/app/shared/form.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-quiz-theme-form',
  templateUrl: './quiz-theme-form.component.html',
  styleUrls: ['./quiz-theme-form.component.scss']
})
export class QuizThemeFormComponent implements OnInit  {

  constructor(
    private route: ActivatedRoute,
    private quizThemeService: QuizThemeService,
    private router: Router,
    private toastr: ToastrService,
    private form: FormService,
    private location: Location
  ) { }

  public quizTheme: any = {};
  public errorMessage = '';


  ngOnInit() {
    this.route.params.subscribe(params => {
      const QuizThemeId = params.id;
      if(QuizThemeId != null) {
        this.getCity(QuizThemeId);
      }
    });
  }

  getCity(QuizThemeId) {
    this.quizThemeService.getOne(QuizThemeId).subscribe(response =>
      {
        this.quizTheme = response;
        this.quizTheme.id = QuizThemeId;
        this.form.hide();
      }
    );
}


onSubmit() {
  this.form.show();
  // this.city.countryId = 1;
  this.quizThemeService.submit(this.quizTheme).subscribe(
    (response: any) => {
      this.toastr.success('Uspješno uneseno');
      this.router.navigate(['quizThemes']);
      this.form.hide();
    },
    (response: any) => {
      const firstError = response.error.errors;
      const firstKey = Object.keys(firstError)[0];
      this.errorMessage = firstError[firstKey][0];
      this.form.hide();
    });
}
goBack() {
  this.location.back();
  this.toastr.warning('Nije uneseno');
}

}

