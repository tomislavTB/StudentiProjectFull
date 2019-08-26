import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(
    private http: HttpClient
  ) { }

  private readonly COURS_URL = 'courses';

  private getRootUrl() {
    return environment.apiUrl + this.COURS_URL;
  }

  private formatUrl(courseId){
    return this.getRootUrl() + '/' + courseId;
  }


  public getAll() {
    return this.http.get(environment.apiUrl + this.COURS_URL);
  }

  public deleteOne(courseId) {
    return this.http.delete(environment.apiUrl + this.COURS_URL + '/' + courseId);
  }


  public getOne(courseId) {
    return this.http.get(environment.apiUrl + this.COURS_URL + '/' + courseId);
  }
  public addOne(course) {
    return this.http.post(this.getRootUrl(), course);
  }

  public putOne(courseId, course) {
    return this.http.put(this.formatUrl(courseId), course);
  }


  public submit(course) {
     if(!course.id) {
      return this.addOne(course);
    }
      return this.putOne(course.id, course);
  }
}

