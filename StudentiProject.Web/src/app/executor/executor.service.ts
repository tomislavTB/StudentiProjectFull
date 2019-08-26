import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ExecutorService {

  constructor(
    private http: HttpClient
  ) { }

  private readonly EXECUTOR_URL = 'executors';

  private getRootUrl() {
    return environment.apiUrl + this.EXECUTOR_URL;
  }

  private formatUrl(executorId){
    return this.getRootUrl() + '/' + executorId;
  }


  public getAll() {
    return this.http.get(environment.apiUrl + this.EXECUTOR_URL);
  }

  public deleteOne(executorId) {
    return this.http.delete(environment.apiUrl + this.EXECUTOR_URL + '/' + executorId);
  }


  public getOne(executorId) {
    return this.http.get(environment.apiUrl + this.EXECUTOR_URL + '/' + executorId);
  }
  public addOne(executor) {
    return this.http.post(this.getRootUrl(), executor);
  }

  public putOne(executorId, executor) {
    return this.http.put(this.formatUrl(executorId), executor);
  }


  public submit(executor) {
     if(!executor.id) {
      return this.addOne(executor);
    }
      return this.putOne(executor.id, executor);
  }
}

