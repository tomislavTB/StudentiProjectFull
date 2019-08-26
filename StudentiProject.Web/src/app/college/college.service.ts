import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { PaginationResponse } from '../shared/Response/PaginationResponse';
import { map } from 'rxjs/operators';
import { College } from './college';

@Injectable({
  providedIn: 'root'
})
export class CollegeService {
  constructor(private http: HttpClient) { }

  private readonly COLLEGE_URL = 'colleges';


  private getRootUrl() {
    return environment.apiUrl + this.COLLEGE_URL;
  }

  private formatUrl(collegeId){
    return this.getRootUrl() + '/' + collegeId;
  }


  public getAll() {
    return this.http.get(environment.apiUrl + this.COLLEGE_URL);
  }

  public getPage(page = 1) {
    return this
      .http
      .get(environment.apiUrl + 'colleges?page=' + page)
      .pipe(
        map((raw: PaginationResponse<College>) => {
          return raw.response;
        })
      );
  }


  public deleteOne(collegeId) {
    return this.http.delete(environment.apiUrl + this.COLLEGE_URL + '/' + collegeId);
  }


  public getOne(collegeId) {
    return this.http.get(environment.apiUrl + this.COLLEGE_URL + '/' + collegeId);
  }


  public addOne(college) {
    return this.http.post(this.getRootUrl(), college);
  }

  public putOne(collegeId, college) {
    return this.http.put(this.formatUrl(collegeId), college);
  }


  public submit(college) {
     if(!college.id) {
      return this.addOne(college);
    }
      return this.putOne(college.id, college);
  }
}

