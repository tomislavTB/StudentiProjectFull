import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GradeService } from '../grade.service';
import { ToastrService } from 'ngx-toastr';
import { FormService } from 'src/app/shared/form.service';
import { StudentService } from 'src/app/student/student.service';
import { CourseService } from 'src/app/course/course.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-grade-form',
  templateUrl: './grade-form.component.html',
  styleUrls: ['./grade-form.component.scss']
})
export class GradeFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private gradeService: GradeService,
    private router: Router,
    private toastr: ToastrService,
    private form: FormService,
    private courseService: CourseService,
    private studentService: StudentService,
    private location: Location
  ) { }

  public grade: any = {};
  public courses: any = [];
  public students: any = [];
  public errorMessage = '';
  public selectedCourseId: any = {};
  public selectedStudentId: any = {};


  ngOnInit() {
    this.route.params.subscribe(params => {
      const gradeId = params.id;
      this.getCourses();
      this.getStudents();
      if(gradeId != null) {
        this.getGrade(gradeId);
      }
    });
  }

  getGrade(gradeId) {
      this.gradeService.getOne(gradeId).subscribe(response =>
        {
          this.grade = response;
          this.grade.id = gradeId;
          this.selectedCourseId = this.grade.courseId;
          this.selectedStudentId = this.grade.studentId;
          this.form.hide();
        }
      );
  }

  onSubmit() {
    this.form.show();
    this.selectedCourseId = this.grade.courseId;
    this.selectedStudentId = this.grade.studentId;

    this.gradeService.submit(this.grade).subscribe(
      (response: any) => {
        this.toastr.success('Bravo');
        this.router.navigate(['grades']);
        this.form.hide();
      },
      (response: any) => {
        const firstError = response.error.errors;
        const firstKey = Object.keys(firstError)[0];
        this.errorMessage = firstError[firstKey][0];
        this.form.hide();
      });
  }
  getCourses() {
    this.courseService.getAll().subscribe(response => {
      this.courses = response;
    }
    );
  }

  goBack() {
    this.location.back();
  }

  getStudents() {
    this.studentService.getAll().subscribe(response => {
      this.students = response;
    }
    );
  }

}

