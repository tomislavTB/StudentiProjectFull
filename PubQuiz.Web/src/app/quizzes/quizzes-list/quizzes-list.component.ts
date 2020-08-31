import { Component, OnInit } from '@angular/core';
import { QuizzesService } from '../quizzes.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormService } from 'src/app/shared/form.service';
import { NgxDatatablePageLimitEnum } from 'src/app/shared/ngx-datatable-page-limit.enum';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { QuizzesFormComponent } from '../quizzes-form/quizzes-form.component';

@Component({
  selector: 'app-quizzes-list',
  templateUrl: './quizzes-list.component.html',
  styleUrls: ['./quizzes-list.component.scss']
})
export class QuizzesListComponent implements OnInit {
  myQuizzess: any;
  public user: any;

  constructor(
    private quizzesService: QuizzesService, 
    private toastr: ToastrService, 
    private router: Router, 
    private form: FormService,
    private ngbModalService: NgbModal,
    ) { }

    private quizzess = [];

    ngOnInit() {
      if(JSON.parse(localStorage.getItem('auth_user'))){
        this.user = JSON.parse(localStorage.getItem('auth_user'))
        if(this.user){
          if(this.user.admin == true){
            this. getQuizzessAdmin();
          }
          else{
            this. getQuizzess(this.user.id);
          }
          
        }
      }
  }


  getQuizzessAdmin() { this.quizzesService.getAll().subscribe((response: any) => {
      const myQuizzessFirst = [];
      
      this.quizzess = response.response.data;
      if(this.quizzess && this.quizzess.length > 0){
        this.quizzess.forEach(row => {
          myQuizzessFirst.push({
              'id': row.id,
              'name': row.name,
              'city': row.city.name,
              'cityId': row.city.id,
              'country':row.country.name,
              'countryId':row.country.id,
              'quizTheme':row.quizTheme.name,
              'quizThemeId':row.quizTheme.id,
              'authUser':row.authUser.email,
              'authUserId':row.authUser.id,
              'dateWhen':row.dateWhen
          });
          
       }  
       
    );
    this.myQuizzess = [...myQuizzessFirst]; 
      }
      
  });
}

    getQuizzess(userId) { this.quizzesService.getAllForHome(userId).subscribe((response: any) => {
      const myQuizzessFirst = [];
      
      this.quizzess = response.response.data;
      if(this.quizzess && this.quizzess.length > 0){
        this.quizzess.forEach(row => {
          myQuizzessFirst.push({
              'id': row.id,
              'name': row.name,
              'city': row.city.name,
              'cityId': row.city.id,
              'country':row.country.name,
              'countryId':row.country.id,
              'quizTheme':row.quizTheme.name,
              'quizThemeId':row.quizTheme.id,
              'authUser':row.authUser.email,
              'authUserId':row.authUser.id,
              'dateWhen':row.dateWhen
          });
          
       }  
       
    );
    this.myQuizzess = [...myQuizzessFirst]; 
      }
      
  });
}

  onDelete(quizzesId) {
    if (confirm('Da li ste sigurni?')) {
      this.quizzesService.deleteOne(quizzesId).subscribe(result => {
        this.toastr.success('Izbrisali ste kolegij.');
        this.getQuizzess(this.user.id);
   });
 }
}

onAdd() {
  const modalRef = this.ngbModalService.open(QuizzesFormComponent, { size: 'lg', backdrop: 'static', keyboard: false});
  modalRef.result.then(result => {
    if (result == 'ok') {
      this.getQuizzess(this.user.id);
    }
    }).catch((res) => {});
    
}

onEdit(row) {
  // this.form.show();
  const modalRef = this.ngbModalService.open(QuizzesFormComponent, { size: 'lg', backdrop: 'static', keyboard: false});
    if(row) {
    modalRef.componentInstance.row = row;
  }
  modalRef.result.then(result => {
    if (result == 'ok') {
      this.getQuizzess(this.user.id);
    }
    }).catch((res) => {});
  
}

get pageLimit() {
  return NgxDatatablePageLimitEnum.limit;
}
}
