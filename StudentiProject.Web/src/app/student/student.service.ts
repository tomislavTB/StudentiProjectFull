import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(
    private http: HttpClient
  ) { }

  private readonly STUDENT_URL = 'students';

  private getRootUrl() {
    return environment.apiUrl + this.STUDENT_URL;
  }

  private formatUrl(studnetId){
    return this.getRootUrl() + '/' + studnetId;
  }

  public getAll() {
    return this.http.get(environment.apiUrl + this.STUDENT_URL);
  }


  public deleteOne(studentId) {
    return this.http.delete(environment.apiUrl + this.STUDENT_URL + '/' + studentId);
  }


  public getOne(studentId) {
    return this.http.get(environment.apiUrl + this.STUDENT_URL + '/' + studentId);
  }
  public addOne(student) {
    return this.http.post(this.getRootUrl(), student);
  }

  public putOne(studentId, student) {
    return this.http.put(this.formatUrl(studentId), student);
  }


  public submit(student) {
     if(!student.id) {
      return this.addOne(student);
    }
      return this.putOne(student.id, student);
  }
}

