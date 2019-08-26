import { Component, OnInit } from '@angular/core';
import { CourseService } from '../course.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormService } from 'src/app/shared/form.service';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.scss']
})
export class CourseListComponent implements OnInit {

  constructor(private courseService: CourseService, private toastr: ToastrService, private router: Router, private form: FormService
    ) { }

    private courses = [];

    ngOnInit() {
      this. getCourses();
  }

    getCourses() { this.courseService.getAll().subscribe((response: any) => {
      this.courses = response;
  });
}

  onDelete(courseId) {
    if (confirm('Da li ste sigurni?')) {
      this.courseService.deleteOne(courseId).subscribe(result => {
        this.courseService.getAll();
        this.toastr.success('Izbrisali ste kolegij.');
        this. getCourses();
   });
 }
}

onAdd() {
   this.router.navigate(['courses/new']);
}

onEdit(courseId) {
  this.form.show();
  this.router.navigate(['courses', courseId]);
}
}
