import { Component, OnInit } from '@angular/core';
import { JwtHelper } from './auth/jwt.helper';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(
    private jwt: JwtHelper
  ) { }

  // tslint:disable-next-line:member-ordering
  public user = {
    email: ''
  };

  title = 'PubQuiz-web';

  ngOnInit() {
    this.setUser();
  }

  public setUser() {
    this.user = this.jwt.getUser();
  }
  public delStorage() {
    localStorage.clear();
    location.href = 'home';
  }
}
