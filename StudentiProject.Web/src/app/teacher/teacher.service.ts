import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  constructor(
    private http: HttpClient
  ) { }

  private readonly TEACHER_URL = 'teachers';

  private getRootUrl() {
    return environment.apiUrl + this.TEACHER_URL;
  }

  private formatUrl(teacherId){
    return this.getRootUrl() + '/' + teacherId;
  }

  public getAll() {
    return this.http.get(environment.apiUrl + this.TEACHER_URL);
  }


  public deleteOne(teacherId) {
    return this.http.delete(environment.apiUrl + this.TEACHER_URL + '/' + teacherId);
  }


  public getOne(teacherId) {
    return this.http.get(environment.apiUrl + this.TEACHER_URL + '/' + teacherId);
  }
  public addOne(teacher) {
    return this.http.post(this.getRootUrl(), teacher);
  }

  public putOne(teacherId, teacher) {
    return this.http.put(this.formatUrl(teacherId), teacher);
  }


  public submit(teacher) {
     if(!teacher.id) {
      return this.addOne(teacher);
    }
      return this.putOne(teacher.id, teacher);
  }
}



