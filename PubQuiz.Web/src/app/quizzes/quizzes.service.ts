import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class QuizzesService{

  constructor(
    private http: HttpClient
  ) { }

  private readonly COURS_URL = 'noticeBoards';

  private getRootUrl() {
    return environment.apiUrl + this.COURS_URL;
  }

  private formatUrl(quizzesId){
    return this.getRootUrl() + '/' + quizzesId;
  }


  public getAll() {
    return this.http.get(environment.apiUrl + this.COURS_URL);
  }

  public deleteOne(quizzesId) {
    return this.http.delete(environment.apiUrl + this.COURS_URL + '/' + quizzesId);
  }


  public getOne(quizzesId) {
    return this.http.get(environment.apiUrl + this.COURS_URL + '/' + quizzesId);
  }
  public addOne(quizzes) {
    return this.http.post(this.getRootUrl(), quizzes);
  }

  public putOne(quizzesId, quizzes) {
    return this.http.put(this.formatUrl(quizzesId), quizzes);
  }


  public submit(quizzes) {
     if(!quizzes.id) {
      return this.addOne(quizzes);
    }
      return this.putOne(quizzes.id, quizzes);
  }
}

