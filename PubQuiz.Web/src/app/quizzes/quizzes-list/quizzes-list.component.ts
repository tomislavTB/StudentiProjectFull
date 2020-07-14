import { Component, OnInit } from '@angular/core';
import { QuizzesService } from '../quizzes.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormService } from 'src/app/shared/form.service';

@Component({
  selector: 'app-quizzes-list',
  templateUrl: './quizzes-list.component.html',
  styleUrls: ['./quizzes-list.component.scss']
})
export class QuizzesListComponent implements OnInit {

  constructor(private quizzesService: QuizzesService, private toastr: ToastrService, private router: Router, private form: FormService
    ) { }

    private quizzess = [];

    ngOnInit() {
      this. getQuizzess();
  }

    getQuizzess() { this.quizzesService.getAll().subscribe((response: any) => {
      this.quizzess = response;
      console.log(response);
      
  });
}

  onDelete(quizzesId) {
    if (confirm('Da li ste sigurni?')) {
      this.quizzesService.deleteOne(quizzesId).subscribe(result => {
        this.quizzesService.getAll();
        this.toastr.success('Izbrisali ste kolegij.');
        this. getQuizzess();
   });
 }
}

onAdd() {
   this.router.navigate(['quizzess/new']);
}

onEdit(quizzesId) {
  this.form.show();
  this.router.navigate(['quizzess', quizzesId]);
}
}
