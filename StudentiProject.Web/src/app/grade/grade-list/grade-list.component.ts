import { Component, OnInit } from '@angular/core';
import { GradeService } from '../grade.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormService } from 'src/app/shared/form.service';

@Component({
  selector: 'app-grade-list',
  templateUrl: './grade-list.component.html',
  styleUrls: ['./grade-list.component.scss']
})
export class GradeListComponent implements OnInit {

  constructor(private gradeService: GradeService, private toastr: ToastrService, private router: Router, private form: FormService
    ) { }

    private grades = [];

    ngOnInit() {
      this.getGrades();
  }

    getGrades() {
    this.gradeService.getAll().subscribe((response: any) => {
        this.grades = response;
    });
  }


  onDelete(gradeId) {
    if (confirm('Da li ste sigurni?')) {
      this.gradeService.deleteOne(gradeId).subscribe(result => {
        this.gradeService.getAll();
        this.toastr.success('Izbrisali ste ocjenu.');
        this.getGrades();
   });
 }
}

onAdd() {
   this.router.navigate(['grades/new']);
}

onEdit(gradeId) {
  this.form.show();
  this.router.navigate(['grades', gradeId]);
}
}

