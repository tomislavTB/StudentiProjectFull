import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExecutorService } from '../executor.service';
import { ToastrService } from 'ngx-toastr';
import { FormService } from 'src/app/shared/form.service';
import { TeacherService } from 'src/app/teacher/teacher.service';
import { CourseService } from 'src/app/course/course.service';
import { Location } from '@angular/common';


@Component({
  selector: 'app-executor-form',
  templateUrl: './executor-form.component.html',
  styleUrls: ['./executor-form.component.scss']
})
export class ExecutorFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private executorService: ExecutorService,
    private router: Router,
    private toastr: ToastrService,
    private form: FormService,
    private teacherService: TeacherService,
    private courseService: CourseService,
    private location: Location
  ) { }

  public executor: any = {};
  public teachers: any = [];
  public courses: any = [];
  public errorMessage = '';
  public selectedTeacherId: any = {};
  public selectedCourseId: any = {};



  ngOnInit() {
    this.route.params.subscribe(params => {
      const executorId = params.id;
      this.getTeachers();
      this.getCourses();
      if(executorId != null) {
        this.getExecutor(executorId);
      }
    });
  }

  getExecutor(executorId) {
      this.executorService.getOne(executorId).subscribe(response =>
        {
          this.executor = response;
          this.executor.id = executorId;
          this.selectedTeacherId = this.executor.teacherId;
          this.selectedCourseId = this.executor.courseId;
          this.form.hide();
        }
      );
  }

  onSubmit() {
    this.form.show();
    this.selectedTeacherId = this.executor.teacherId;
    this.selectedCourseId = this.executor.courseId;
    // this.city.countryId = 1;
    this.executorService.submit(this.executor).subscribe(
      (response: any) => {
        this.toastr.success('Uspješno uneseno');
        this.router.navigate(['executors']);
        this.form.hide();
      },
      (response: any) => {
        const firstError = response.error.errors;
        const firstKey = Object.keys(firstError)[0];
        this.errorMessage = firstError[firstKey][0];
        this.form.hide();
      });

  }
  getTeachers() {
    this.teacherService.getAll().subscribe(response => {
      this.teachers = response;
    }

    );
  }

  goBack() {
    this.location.back();
  }

  getCourses() {
    this.courseService.getAll().subscribe(response => {
      this.courses = response;
    }
    );
  }
}
