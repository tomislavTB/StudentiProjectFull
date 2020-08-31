import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { PaginationResponse } from '../shared/Response/PaginationResponse';
import { map } from 'rxjs/operators';
import { City } from './city';
import { JwtHelper } from '../auth/jwt.helper';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  constructor(private http: HttpClient,
              private jwt: JwtHelper) { }

  private readonly CITIES_URL = 'cities';

  private getRootUrl() {
    return environment.apiUrl + this.CITIES_URL;
  }

  private formatUrl(cityId) {
    return this.getRootUrl() + '/' + cityId;
  }

  public getAll() {
    const token = this.jwt.getFullToken();
    let headers = new  HttpHeaders().set('Authorization', token);
    return this.http.get(environment.apiUrl + this.CITIES_URL);
  }

  public deleteOne(cityId) {
    return this.http.delete(
      environment.apiUrl + this.CITIES_URL + '/' + cityId
    );
  }

  public getOne(cityId) {
    return this.http.get(environment.apiUrl + this.CITIES_URL + '/' + cityId);
  }

  public addOne(city) {
    return this.http.post(this.getRootUrl(), city);
  }

  public putOne(cityId, city) {
    return this.http.put(this.formatUrl(cityId), city);
  }

  // public getPage(page = 1) {
  //   return this
  //     .http
  //     .get(environment.apiUrl + 'cities?page=' + page)
  //     .pipe(
  //       map((raw: PaginationResponse<City>) => {
  //         return raw.response;
  //       })
  //     );
  // }

  public submit(city) {
    if (!city.id) {
      return this.addOne(city);
    }
    return this.putOne(city.id, city);
  }
}
