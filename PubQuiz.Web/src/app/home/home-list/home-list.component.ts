import { Component, OnInit } from '@angular/core';
import { HomeService } from '../home.service';
import { JwtHelper } from 'src/app/auth/jwt.helper';

@Component({
  selector: 'app-home-list',
  templateUrl: './home-list.component.html',
  styleUrls: ['./home-list.component.scss']
})
export class HomeListComponent implements OnInit {

  constructor(
    private jwt: JwtHelper
  ) { }

  // tslint:disable-next-line:member-ordering
  public user = {
    email: ''
  };

  title = 'StudentiProject-web';

  ngOnInit() {
    this.setUser();
  }

  public setUser() {
    this.user = this.jwt.getUser();
  }
}
