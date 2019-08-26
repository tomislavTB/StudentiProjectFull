import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CityModule } from './city/city.module';
import { TeacherModule } from './teacher/teacher.module';
import { StudentModule } from './student/student.module';
import { GradeModule } from './grade/grade.module';
import { ExecutorModule } from './executor/executor.module';
import { DivisionModule } from './division/division.module';
import { CourseModule } from './course/course.module';
import { CollegeModule } from './college/college.module';
import { CountryModule } from './country/country.module';
import { HttpClientModule } from '@angular/common/http';
import { HomeModule } from './home/home.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CountryModule,
    CollegeModule,
    CourseModule,
    DivisionModule,
    ExecutorModule,
    GradeModule,
    StudentModule,
    TeacherModule,
    CityModule,
    HomeModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
