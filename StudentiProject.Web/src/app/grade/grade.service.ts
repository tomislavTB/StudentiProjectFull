import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GradeService {

  constructor(
    private http: HttpClient
  ) { }

  private readonly GRADE_URL = 'grades';

  private getRootUrl() {
    return environment.apiUrl + this.GRADE_URL;
  }

  private formatUrl(gradeId){
    return this.getRootUrl() + '/' + gradeId;
  }


  public getAll() {
    return this.http.get(environment.apiUrl + this.GRADE_URL);
  }


  public deleteOne(gradeId) {
    return this.http.delete(environment.apiUrl + this.GRADE_URL + '/' + gradeId);
  }


  public getOne(gradeId) {
    return this.http.get(environment.apiUrl + this.GRADE_URL + '/' + gradeId);
  }
  public addOne(grade) {
    return this.http.post(this.getRootUrl(), grade);
  }

  public putOne(gradeId, grade) {
    return this.http.put(this.formatUrl(gradeId), grade);
  }


  public submit(grade) {
     if(!grade.id) {
      return this.addOne(grade);
    }
      return this.putOne(grade.id, grade);
  }
}

