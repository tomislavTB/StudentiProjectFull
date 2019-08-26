import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from '../student.service';
import { ToastrService } from 'ngx-toastr';
import { FormService } from 'src/app/shared/form.service';
import { CityService } from 'src/app/city/city.service';
import { DivisionService } from 'src/app/division/division.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.scss']
})
export class StudentFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private studentService: StudentService,
    private router: Router,
    private toastr: ToastrService,
    private form: FormService,
    private cityService: CityService,
    private divisionService: DivisionService,
    private location: Location
  ) { }

  public student: any = {};
  public errorMessage = '';
  public selectedCityId: any = {};
  public cities: any = [];
  public divisions: any = [];
  public selectedDivisionId: any = {};


  ngOnInit() {
    this.route.params.subscribe(params => {
      const studentId = params.id;
      this.getCities();
      this.getDivisions();

      if(studentId != null) {
        this.getStudent(studentId);
      }
    });
  }

  getStudent(studentId) {
      this.studentService.getOne(studentId).subscribe(response =>
        {
          this.student = response;
          this.student.id = studentId;
          this.selectedCityId = this.student.cityId;
          this.selectedDivisionId = this.student.divisionId;
          this.form.hide();
        }
      );
  }

  onSubmit() {
    this.form.show();
    this.selectedCityId = this.student.cityId;
    this.selectedDivisionId = this.student.divisionId;
    this.studentService.submit(this.student).subscribe(
      (response: any) => {
        this.toastr.success('Bravo');
        this.router.navigate(['students']);
        this.form.hide();
      },
      (response: any) => {
        const firstError = response.error.errors;
        const firstKey = Object.keys(firstError)[0];
        this.errorMessage = firstError[firstKey][0];
        this.form.hide();
      });
  }
  getCities() {
    this.cityService.getAll().subscribe(response => {
      this.cities = response;
    }
    );

  }

  goBack() {
    this.location.back();
  }
  getDivisions() {
    this.divisionService.getAll().subscribe(response => {
      this.divisions = response;
    }
    );
  }
}
