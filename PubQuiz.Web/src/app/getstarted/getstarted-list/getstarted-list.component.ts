import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/auth/login.service';
import { JwtHelper } from 'src/app/auth/jwt.helper';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-getstarted-list',
  templateUrl: './getstarted-list.component.html',
  styleUrls: ['./getstarted-list.component.scss']
})
export class GetstartedListComponent implements OnInit {

  private router: Router;

  constructor(
    private auth: LoginService,
    private jwt: JwtHelper,
    private toastr: ToastrService
  ) { }

  public loginData = {
    email: '',
    password: ''
  };

  public registerData = {
    firstname: '',
    lastname: '',
    email: '',
    password: ''
  };

  ngOnInit() {
  }

  public onSubmit() {
    this.auth.register(this.registerData).subscribe((response: any) => {
      
      const token = response.token;
      this.jwt.setToken(token);
      this.jwt.setUser(response.user);
      location.href = 'home';
      this.toastr.success('Uspješno ste se registrirali');
    }, error => {
      this.toastr.error('Neuspješna registracija, provjerite unesene podatke');
      this.registerData.password = '';
    });
    return false;
  }

  public loginSubmit() {
    this.auth.login(this.loginData).subscribe((response: any) => {
      const token = response.token;
      this.jwt.setToken(token);
      this.jwt.setUser(response.user);
      location.href = 'home';
      this.toastr.success('Uspješno ste se prijavili');
    }, error => {
      this.toastr.error('Pogrešna kombinacija emaila/lozinke.');
      this.loginData.password = '';
    });
    return false;
  }
}
