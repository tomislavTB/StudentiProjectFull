import { Component, OnInit } from '@angular/core';
import { HomeService } from '../home.service';
import { JwtHelper } from 'src/app/auth/jwt.helper';
import { QuizzesService } from 'src/app/quizzes/quizzes.service';
import { FormGroup, FormBuilder, AbstractControl } from '@angular/forms';
import { CountryService } from 'src/app/country/country.service';
import { QuizThemeService } from 'src/app/quiz-theme/quiz-theme.service';
import { CityService } from 'src/app/city/city.service';
import * as moment from 'moment';

@Component({
  selector: 'app-home-list',
  templateUrl: './home-list.component.html',
  styleUrls: ['./home-list.component.scss']
})
export class HomeListComponent implements OnInit {
  myQuizzess: any;
  staticValues: any;
  constructor(
    private jwt: JwtHelper,
    private quizzesService: QuizzesService, 
    private formBuilder: FormBuilder,
    private countryService: CountryService,
    private cityService: CityService,
    private themeService: QuizThemeService,
  ) { }
    private quizzess = [];
    public countries: any = [];
    public cities : any = [];
    public themes: any = [];
    timeToday: Date = new Date();
    todayDate: any;

  // tslint:disable-next-line:member-ordering
  public user = {
    email: ''
  };

  

  
  filter: FormGroup = this.formBuilder.group({

    cityFilter: null,
    countryFilter: null,
    quizThemeFilter: null,
    dateWhen: null
  });

  title = 'QuizTheme-web';

  ngOnInit() {
    this.setUser();
    this.getQuizzess();
    this.getCountries();
    this.getCities();
    this.getThemes();
    this.todayDate = moment(Date.now()).format("yyyy-MM-dd'T'HH:mm:ss.SSS");
  }

  public setUser() {
    this.user = this.jwt.getUser();
  }

  getQuizzess() { this.quizzesService.getAll().subscribe((response: any) => {
    const myQuizzessFirst = [];
    
    this.quizzess = response.response.data;

    
    

    if(this.quizzess && this.quizzess.length > 0){
      this.quizzess.forEach(row => {
        if(row.dateWhen > this.todayDate)
        myQuizzessFirst.push({
            'name': row.name,
            'city':row.city.name,
            'cityId':row.city.id,
            'country':row.country.name,
            'countryId':row.country.id,
            'quizTheme':row.quizTheme.name,
            'quizThemeId':row.quizTheme.id,
            'authUser':row.authUser.email,
            'dateWhen':row.dateWhen
        });
        
     }  
     
  );
  this.myQuizzess = [...myQuizzessFirst]; 
  this.staticValues = [...myQuizzessFirst]; 
    }
    
});
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

filterMainTable(event?) {
  
  if (event) {
    if(this.cityFilter.value) {
      this.myQuizzess = this.myQuizzess.filter(data => {
        return data.cityId == this.cityFilter.value;
      });
    }
    if(this.countryFilter.value) {
      this.myQuizzess = this.myQuizzess.filter(data => {
        return data.countryId == this.countryFilter.value;
      });
    }
    if(this.quizThemeFilter.value) {
      this.myQuizzess = this.myQuizzess.filter(data => {
        return data.quizThemeId == this.quizThemeFilter.value;
      });
    }
  }
}

patchGroupValue(formControl, newValue) {
  this.filter.patchValue({
    [formControl]: newValue
  });
}

clear(){
  this.patchGroupValue('cityFilter',null);
  this.patchGroupValue('countryFilter',null);
  this.patchGroupValue('quizThemeFilter',null);
  this.getQuizzess();
}

get cityFilter(): AbstractControl {
  return this.filter.get('cityFilter');
}
get countryFilter(): AbstractControl {
  return this.filter.get('countryFilter');
}
get quizThemeFilter(): AbstractControl {
  return this.filter.get('quizThemeFilter');
}
}
