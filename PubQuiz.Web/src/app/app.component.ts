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
    email: '',
    admin: false
  };
  admin: boolean;

  title = 'PubQuiz-web';

  ngOnInit() {
    this.setUser();
  }

  public setUser() {
    this.user = this.jwt.getUser();
    if(this.user){
      if(this.user.admin == true){
        this.admin = true
      }
    }
  }
  public delStorage() {
    localStorage.clear();
    location.href = 'home';
  }
}
