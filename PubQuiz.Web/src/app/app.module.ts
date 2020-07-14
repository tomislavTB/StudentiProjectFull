import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CityModule } from './city/city.module';
import { CountryModule } from './country/country.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HomeModule } from './home/home.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { GetstartedModule } from './getstarted/getstarted.module';
import { AuthTokenInterceptor } from './shared/auth-token.interceptor';
import { QuizThemeModule } from './quiz-theme/quiz-theme.module';
import { QuizzesModule } from './quizzes/quizzes.module';
import { ChampionListComponent } from './champion/champion-list/champion-list.component';
import { ChampionFormComponent } from './champion/champion-form/champion-form.component';
import { ChampionModule } from './champion/champion.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    GetstartedModule,
    CountryModule,
    QuizThemeModule,
    CityModule,
    HomeModule,
    HttpClientModule,
    BrowserAnimationsModule,
    QuizzesModule,
    ChampionModule,
    ToastrModule.forRoot()

  ],
    providers: [
      { provide: HTTP_INTERCEPTORS, useClass: AuthTokenInterceptor, multi: true}
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
