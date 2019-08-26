import { Component, OnInit } from '@angular/core';
import { TeacherService } from '../teacher.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormService } from 'src/app/shared/form.service';

@Component({
  selector: 'app-teacher-list',
  templateUrl: './teacher-list.component.html',
  styleUrls: ['./teacher-list.component.scss']
})
export class TeacherListComponent implements OnInit {

  constructor(private teacherService: TeacherService, private toastr: ToastrService, private router: Router, private form: FormService
    ) { }


    private teachers = [];

    ngOnInit() {
    this. getTeachers();
  }

  getTeachers() {
    this.teacherService.getAll().subscribe((response: any) => {
      this.teachers = response;
    });
  }



  onDelete(teacherId) {
    if (confirm('Da li ste sigurni?')) {
      this.teacherService.deleteOne(teacherId).subscribe(result => {
        this.teacherService.getAll();
        this.toastr.success('Izbrisali ste profesora.');
        this. getTeachers();
   });
 }
}

onAdd() {
   this.router.navigate(['teachers/new']);
}

onEdit(teacherId) {
  this.form.show();
  this.router.navigate(['teachers', teacherId]);
}
}

