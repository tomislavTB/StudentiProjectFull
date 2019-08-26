import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(
    private http: HttpClient
  ) { }

  private readonly HOME_URL = 'homes';

  public getAll() {
    return this.http.get(environment.apiUrl + this.HOME_URL);
  }
}
