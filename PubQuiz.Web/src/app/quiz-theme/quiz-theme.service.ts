import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class QuizThemeService {

  constructor(
    private http: HttpClient
  ) { }

  private readonly COURS_URL = 'quizThemes';

  private getRootUrl() {
    return environment.apiUrl + this.COURS_URL;
  }

  private formatUrl(quizThemeId){
    return this.getRootUrl() + '/' + quizThemeId;
  }


  public getAll() {
    return this.http.get(environment.apiUrl + this.COURS_URL);
    
  }

  public deleteOne(quizThemeId) {
    return this.http.delete(environment.apiUrl + this.COURS_URL + '/' + quizThemeId);
  }


  public getOne(quizThemeId) {
    return this.http.get(environment.apiUrl + this.COURS_URL + '/' + quizThemeId);
  }
  public addOne(quizTheme) {
    return this.http.post(this.getRootUrl(), quizTheme);
  }

  public putOne(quizThemeId, quizTheme) {
    return this.http.put(this.formatUrl(quizThemeId), quizTheme);
  }


  public submit(quizTheme) {
     if(!quizTheme.id) {
      return this.addOne(quizTheme);
    }
      return this.putOne(quizTheme.id, quizTheme);
  }
}

