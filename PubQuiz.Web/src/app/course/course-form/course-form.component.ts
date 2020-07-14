import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from '../course.service';
import { ToastrService } from 'ngx-toastr';
import { FormService } from 'src/app/shared/form.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-course-form',
  templateUrl: './course-form.component.html',
  styleUrls: ['./course-form.component.scss']
})
export class CourseFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private courseService: CourseService,
    private router: Router,
    private toastr: ToastrService,
    private form: FormService,
    private location: Location
  ) { }

  public course : any = {};
  public divisions: any = [];
  public errorMessage = '';
  public selectedDivisionId: any = {};


  ngOnInit() {
    this.route.params.subscribe(params => {
      const courseId = params.id;
      if(courseId != null) {
        this.getCourse(courseId);
      }
    });
  }

  getCourse(courseId) {
      this.courseService.getOne(courseId).subscribe(response =>
        {
          this.course = response;
          this.course.id = courseId;
          this.selectedDivisionId = this.course.divisionId;
          this.form.hide();
        }
      );
  }

  onSubmit() {
    this.form.show();
    this.selectedDivisionId = this.course.divisionId;
    this.courseService.submit(this.course).subscribe(
      (response: any) => {
        this.toastr.success('Uspješno uneseno');
        this.router.navigate(['courses']);
        this.form.hide();
      },
      (response: any) => {
        const firstError = response.error.errors;
        const firstKey = Object.keys(firstError)[0];
        this.errorMessage = firstError[firstKey][0];
        this.form.hide();
      });
  }

  goBack() {
    this.location.back();
  }
}


