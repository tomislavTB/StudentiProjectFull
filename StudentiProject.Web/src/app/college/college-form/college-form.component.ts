import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CollegeService } from '../college.service';
import { ToastrService } from 'ngx-toastr';
import { FormService } from 'src/app/shared/form.service';
import { CityService } from 'src/app/city/city.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-college-form',
  templateUrl: './college-form.component.html',
  styleUrls: ['./college-form.component.scss']
})
export class CollegeFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private collegeService: CollegeService,
    private router: Router,
    private toastr: ToastrService,
    private form: FormService,
    private cityService: CityService,
    private location: Location
  ) { }

  public college : any = {};
  public errorMessage = '';
  public selectedCityId: any = {};
  public cities: any = [];

  ngOnInit() {
    this.route.params.subscribe(params => {
      const collegeId = params.id;
      this.getCities();
      if(collegeId != null) {
        this.getCollege(collegeId);
      }
    });
  }

  getCollege(collegeId) {
      this.collegeService.getOne(collegeId).subscribe(response =>
        {
          this.college = response;
          this.college.id = collegeId;
          this.selectedCityId = this.college.cityId;
          this.form.hide();
        }
      );
  }

  onSubmit() {
    this.form.show();
    this.selectedCityId = this.college.cityId;
    this.collegeService.submit(this.college).subscribe(
      (response: any) => {
        this.toastr.success('Bravo');
        this.router.navigate(['colleges']);
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
      this.cities = response.response.data;;
    }
    );
  }

}
