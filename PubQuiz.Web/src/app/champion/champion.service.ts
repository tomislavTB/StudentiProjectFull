import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelper } from '../auth/jwt.helper';
import { environment } from 'src/environments/environment';
import { PaginationResponse } from '../shared/Response/PaginationResponse';
import { Champion } from './champion';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ChampionService {
  constructor(private http: HttpClient,
              private jwt: JwtHelper) { }

  private readonly CHAMPIONS_URL = 'champions';

  private getRootUrl() {
    return environment.apiUrl + this.CHAMPIONS_URL;
  }

  private formatUrl(championId) {
    return this.getRootUrl() + '/' + championId;
  }


  public getAll() {
    return this.http.get(environment.apiUrl + this.CHAMPIONS_URL);
    
  }


  public deleteOne(championId) {
    return this.http.delete(
      environment.apiUrl + this.CHAMPIONS_URL + '/' + championId
    );
  }

  public getOne(championId) {
    return this.http.get(environment.apiUrl + this.CHAMPIONS_URL + '/' + championId);
  }

  public addOne(champion) {
    return this.http.post(this.getRootUrl(), champion);
  }

  public putOne(championId, champion) {
    return this.http.put(this.formatUrl(championId), champion);
  }

  public getPage(page = 1) {
    return this
      .http
      .get(environment.apiUrl + 'champions?page=' + page)
      .pipe(
        map((raw: PaginationResponse<any>) => {
          return raw.response;
        })
      );
  }

  public submit(champion) {
    if (!champion.id) {
      return this.addOne(champion);
    }
    return this.putOne(champion.id, champion);
  }
}
