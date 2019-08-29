import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DivisionService } from '../division.service';
import { ToastrService } from 'ngx-toastr';
import { FormService } from 'src/app/shared/form.service';
import { CollegeService } from 'src/app/college/college.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-division-form',
  templateUrl: './division-form.component.html',
  styleUrls: ['./division-form.component.scss']
})
export class DivisionFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private divisionService: DivisionService,
    private router: Router,
    private toastr: ToastrService,
    private form: FormService,
    private collegeService: CollegeService,
    private location: Location
  ) { }

  public division : any = {};
  public colleges: any = [];
  public errorMessage = '';
  public selectedCollegeId: any = {};

  ngOnInit() {
    this.route.params.subscribe(params => {
      const divisionId = params.id;
      this.getColleges();
      if(divisionId != null) {
        this.getDivision(divisionId);
      }
    });
  }

  getDivision(divisionId) {
      this.divisionService.getOne(divisionId).subscribe(response =>
        {
          this.division = response;
          this.division.id = divisionId;
          this.selectedCollegeId = this.division.collegeId;
          this.form.hide();
        }
      );
  }

  onSubmit() {
    this.form.show();
    this.selectedCollegeId = this.division.collegeId;
    // this.city.countryId = 1;
    this.divisionService.submit(this.division).subscribe(
      (response: any) => {
        this.toastr.success('Uspješno uneseno');
        this.router.navigate(['divisions']);
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
  getColleges() {
    this.collegeService.getAll().subscribe((response: any) => {
      this.colleges = response.response.data;
    }
    );
  }

}
