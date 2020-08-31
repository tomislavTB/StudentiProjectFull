import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class QuizzesService{

  constructor(
    private http: HttpClient
  ) { }

  formatDate: any;

  private readonly COURS_URL = 'NoticeBoards';

  private getRootUrl() {
    return environment.apiUrl + this.COURS_URL;
  }

  private formatUrl(quizzesId){
    return this.getRootUrl() + '/' + quizzesId;
  }


  public getAll() {
    return this.http.get(environment.apiUrl + this.COURS_URL + '/' + 'getNoticeboards');
  }
  
  public getAllForHome(userId) {
    const request2 = {
      userId : userId,
      request: null
    }
    
    return this.http.post(environment.apiUrl + this.COURS_URL + '/' + 'getNoticeboardsPost', request2);
  }
  public deleteOne(quizzesId) {
    return this.http.delete(environment.apiUrl + this.COURS_URL + '/' + quizzesId);
  }


  public getOne(quizzesId) {
    return this.http.get(environment.apiUrl + this.COURS_URL + '/' + quizzesId);
  }
  public addOne(quizzes) {
    this.formatDate = moment(quizzes.dateWhen).add(-1, 'M').format('YYYY-MM-DD');
    
    let quizData = {
      AuthUserId: quizzes.authUserId,
      QuizThemeId: quizzes.quizThemeId,
      CountryId: quizzes.countryId,
      CityId: quizzes.cityId,
      Name: quizzes.name,
      DateWhen: new Date(this.formatDate)
    }
    
    return this.http.post(this.getRootUrl() + '/noticeBoards', quizData);
  }

  public putOne(quizzesId, quizzes) {
    
    let quizData = {
      AuthUserId: quizzes.authUserId,
      QuizThemeId: quizzes.quizThemeId,
      CountryId: quizzes.countryId,
      CityId: quizzes.cityId,
      Name: quizzes.name,
      DateWhen: new Date(quizzes.dateWhen)
    }
    return this.http.put(this.formatUrl(quizzesId), quizData);
  }


  public submit(quizzes, isEdit) {
     if(isEdit == false) {
      return this.addOne(quizzes);
    }
      return this.putOne(quizzes.id, quizzes);
  }
}

