import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormService } from 'src/app/shared/form.service';
import { NgxDatatablePageLimitEnum } from 'src/app/shared/ngx-datatable-page-limit.enum';
import { QuizzesService } from 'src/app/quizzes/quizzes.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {

  constructor(private userService: UserService, private toastr: ToastrService, private router: Router, private form: FormService, private quizzesService: QuizzesService, ) { }
  newUsers: any;
  CountUsers: any;
  countQuizzes: any;
  login: any;
  finalCount: number;
  finalCountQuizz: number;
  private users = [];
  private quizzess = [];

  
  
  ngOnInit() {
    this.getUsers();
    this.getQuizzess();
    this.login = localStorage.getItem('auth_user')

    
  }
  getUsers() {
    this.userService
    .getAll()
    .subscribe((response: any) =>  {
    const users = [];
    this.users = response.response;
    
    if(this.users && this.users.length > 0){
      this.users.forEach(row => {
        users.push({
            'id': row.id,
            'firstName': row.firstName,
            'lastName': row.lastName,
            'email': row.email,
        });
        
     }  
     
  );
  this.newUsers = [...users]; 
  this.CountUsers =  this.newUsers
  
  for(var i = 0; i < this.newUsers.length; ++i){
    if(this.newUsers[i] == 2)
    this.CountUsers++;
}
  this.finalCount = this.CountUsers.length
    }
  });

  }

  getQuizzess() { this.quizzesService.getAll().subscribe((response: any) => {
  this.quizzess = response.response.data;
  this.finalCountQuizz = this.quizzess.length
});
}

  onDelete(userId) {
    if (confirm('Da li ste sigurni?')) {
      this.userService.deleteOne(userId).subscribe(result => {
        this.userService.getAll();
        this.toastr.success('Izbrisali ste državu.');
        this.getUsers();
   });
 }
}

onClick(){
  this.getUsers();
  this.getQuizzess();
  

}
get pageLimit() {
  return NgxDatatablePageLimitEnum.limit;
}


}
