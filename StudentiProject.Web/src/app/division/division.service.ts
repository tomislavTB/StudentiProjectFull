import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DivisionService {

  constructor(
    private http: HttpClient
  ) { }

  private readonly DIVISION_URL = 'divisions';

  private getRootUrl() {
    return environment.apiUrl + this.DIVISION_URL;
  }

  private formatUrl(divisionId){
    return this.getRootUrl() + '/' + divisionId;
  }


  public getAll() {
    return this.http.get(environment.apiUrl + this.DIVISION_URL);
  }

  public deleteOne(divisionId) {
    return this.http.delete(environment.apiUrl + this.DIVISION_URL + '/' + divisionId);
  }


  public getOne(divisionId) {
    return this.http.get(environment.apiUrl + this.DIVISION_URL + '/' + divisionId);
  }
  public addOne(division) {
    return this.http.post(this.getRootUrl(), division);
  }

  public putOne(divisionId, division) {
    return this.http.put(this.formatUrl(divisionId), division);
  }


  public submit(division) {
     if(!division.id) {
      return this.addOne(division);
    }
      return this.putOne(division.id, division);
  }
}
