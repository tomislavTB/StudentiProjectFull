import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormService } from 'src/app/shared/form.service';
import { CountryService } from 'src/app/country/country.service';
import { Location } from '@angular/common';
import { CityService } from 'src/app/city/city.service';
import { QuizThemeService } from 'src/app/quiz-theme/quiz-theme.service';
import * as ClassicEditorBuild from '@ckeditor/ckeditor5-build-classic';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { QuizzesService } from '../quizzes.service';
import { NgbActiveModal, NgbDateParserFormatter, NgbDatepickerI18n } from '@ng-bootstrap/ng-bootstrap';
import { NgbDateCustomParserFormatter } from 'src/app/shared/ngb-date-custom-parser-formatter';
import { CustomDatepickerI18n } from 'src/app/shared/custom-date-picker-i18n';
import * as moment from 'moment';


@Component({
  selector: 'app-quizzes-form',
  templateUrl: './quizzes-form.component.html',
  styleUrls: ['./quizzes-form.component.scss'],
  providers: [
    { provide: NgbDateParserFormatter, useClass: NgbDateCustomParserFormatter },
    { provide: NgbDatepickerI18n, useClass: CustomDatepickerI18n }
  ]
})
export class QuizzesFormComponent implements OnInit, OnDestroy {
  ngOnDestroy(): void {
    // throw new Error("Method not implemented.");
  }

  @Input() row;

  constructor(
    private route: ActivatedRoute,
    private cityService: CityService,
    private router: Router,
    private toastr: ToastrService,
    private form: FormService,
    private countryService: CountryService,
    private quizzService: QuizzesService,
    private themeService: QuizThemeService,
    private location: Location,
    private formBuilder: FormBuilder,
    public modal: NgbActiveModal,
    private quizzesService: QuizzesService, 

  ) { }

  public city: any = {};
  public countries: any = [];
  public cities : any = [];
  public themes: any = [];
  public errorMessage = '';
  public selectedCountryId: any = {};
  public Editor = ClassicEditorBuild;
  public user: any;

  modalNoteGroup: FormGroup = this.formBuilder.group({
    id: [null],
    cityId: [null, Validators.required],
    countryId: [null, Validators.required],
    quizThemeId: [null, Validators.required],
    name: ['Ovdje piši obavijest'],
    dateWhen: [null, Validators.required],
    authUserId: [null]
  });

  ngOnInit() {
    // this.route.params.subscribe(params => {
    //   const QuizId = params.id;
    //   if(QuizId != null) {
    //     this.getQuiz(QuizId);
    //   }
    // })


      this.getCountries();
      this.getCities();
      this.getThemes();
if(JSON.parse(localStorage.getItem('auth_user'))){
  this.user = JSON.parse(localStorage.getItem('auth_user'))
  if(this.user){
    this.modalNoteGroup.patchValue({
      authUserId : this.user.id
    })
  }
}
    
    //   this.modalNoteGroup.patchValue({
    //     authUserId : JSON.parse(localStorage.getItem('auth_user'))
    //   })

    if(this.row){
     this.quizzesService.getAll().subscribe((response: any) => {
      let selectedQuizzes = response.response.data.find(x => x.id === this.row.id);
      
      let newDateWhen = {
        year: Number(moment(selectedQuizzes.dateWhen).format('YYYY')),
        month: Number(moment(selectedQuizzes.dateWhen).format('MM')),
        day: Number(moment(selectedQuizzes.dateWhen).format('DD'))
      }
      
      this.modalNoteGroup.patchValue({
        id: selectedQuizzes.id,
        cityId: selectedQuizzes.city.id,
        countryId: selectedQuizzes.country.id,
        quizThemeId: selectedQuizzes.quizTheme.id,
        name: selectedQuizzes.name,
        dateWhen: newDateWhen,
        authUserId: selectedQuizzes.authUser.id
      })
  });
    }

  }

  


  // getQuiz(QuizId) {
  //     this.quizzService.getOne(QuizId).subscribe(response =>
  //       {

  //         this.modalNoteGroup.patchValue({
            
  //         })
  //       }
  //     );
  // }


  date(event){
    this.modalNoteGroup.patchValue({
      dateWhen : this.user.id
    })

  }
  onSubmit() {
    this.form.show();
    if(this.row){
      this.modalNoteGroup.patchValue({
        dateWhen: moment(this.modalNoteGroup.value.dateWhen).add(-1, 'M').format('YYYY-MM-DD'),
      })
      this.quizzService.submit(this.modalNoteGroup.value, true).subscribe(
        (response: any) => {
          this.toastr.success('Uspješno uneseno');
          this.modal.close('ok')
          this.form.hide();
        },
        (response: any) => {
          const firstError = response.error.errors;
          const firstKey = Object.keys(firstError)[0];
          this.errorMessage = firstError[firstKey][0];
          this.form.hide();
        });
    }      
    else{
      this.quizzService.submit(this.modalNoteGroup.value, false).subscribe(
        (response: any) => {
          this.toastr.success('Uspješno uneseno');
          this.modal.close('ok')
          this.form.hide();
        },
        (response: any) => {
          const firstError = response.error.errors;
          const firstKey = Object.keys(firstError)[0];
          this.errorMessage = firstError[firstKey][0];
          this.form.hide();
        });
    }
  }
  goBack() {
    this.modal.close()
    this.toastr.warning('Nije uneseno');
  }
  getCountries() {
    this.countryService.getAll().subscribe((response: any) => {
      this.countries = response.response.data;
    }
    );
  }

  getCities() {
    this.cityService.getAll().subscribe((response: any) => {
      this.cities = response.response.data;
    }
    );
  }
  

  getThemes() {
    this.themeService.getAll().subscribe((response: any) => {
      this.themes = response.response.data;
    }
    );
  }

  get cityId(): AbstractControl {
    return this.modalNoteGroup.get('cityId');
  }
  
  get noteId(): AbstractControl {
    return this.modalNoteGroup.get('noteId');
  }

  get countryId (): AbstractControl {
    return this.modalNoteGroup.get('countryId');
  }

  get content(): AbstractControl {
    return this.modalNoteGroup.get('content');
  }

  get themeId(): AbstractControl {
    return this.modalNoteGroup.get('themeId');
  }

}

