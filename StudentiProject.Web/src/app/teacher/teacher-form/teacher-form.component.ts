import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormService } from 'src/app/shared/form.service';
import { CityService } from 'src/app/city/city.service';
import { TeacherService } from '../teacher.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-teacher-form',
  templateUrl: './teacher-form.component.html',
  styleUrls: ['./teacher-form.component.scss']
})
export class TeacherFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private teacherService: TeacherService,
    private router: Router,
    private toastr: ToastrService,
    private form: FormService,
    private cityService: CityService,
    private location: Location
  ) { }

  public teacher: any = {};
  public errorMessage = '';
  public selectedCityId: any = {};
  public cities: any = [];

  ngOnInit() {
    this.route.params.subscribe(params => {
      const teacherId = params.id;
      this.getCities();
      if(teacherId != null) {
        this.getTeacher(teacherId);
      }
    });
  }

  getTeacher(teacherId) {
      this.teacherService.getOne(teacherId).subscribe(response =>
        {
          this.teacher = response;
          this.teacher.id = teacherId;
          this.selectedCityId = this.teacher.cityId;
          this.form.hide();
        }
      );
  }

  onSubmit() {
    this.form.show();
    this.selectedCityId = this.teacher.cityId;
    this.teacherService.submit(this.teacher).subscribe(
      (response: any) => {
        this.toastr.success('Uspješno uneseno');
        this.router.navigate(['teachers']);
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
  getCities() {
    this.cityService.getAll().subscribe((response: any) => {
      this.cities = response.response.data;
    }
    );
  }

}
