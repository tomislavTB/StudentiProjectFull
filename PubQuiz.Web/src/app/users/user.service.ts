import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class UserService{

  constructor(
    private http: HttpClient
  ) { }

  formatDate: any;

  private readonly COURS_URL = 'Auth';

  private getRootUrl() {
    return environment.apiUrl + this.COURS_URL;
  }

  private formatUrl(usersId){
    return this.getRootUrl() + '/' + usersId;
  }


  public getAll() {
    return this.http.get(environment.apiUrl + this.COURS_URL + '/' + 'getAll');
  }
  
  public deleteOne(usersId) {
    return this.http.delete(environment.apiUrl + this.COURS_URL + '/' + usersId);
  }
}

