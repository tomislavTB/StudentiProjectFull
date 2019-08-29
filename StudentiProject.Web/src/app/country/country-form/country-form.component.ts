import { Component, OnInit } from '@angular/core';
import { CountryService } from '../country.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormService } from 'src/app/shared/form.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-country-form',
  templateUrl: './country-form.component.html',
  styleUrls: ['./country-form.component.scss']
})
export class CountryFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private countryService: CountryService,
    private router: Router,
    private toastr: ToastrService,
    private form: FormService,
    private location: Location
  ) { }

  public country: any = {};
  public errorMessage = '';
  public selectedCountryId: any = {};


  ngOnInit() {
    this.route.params.subscribe(params => {
      const countryId = params['id'];
      if(countryId != null) {
        this.getCountry(countryId);
      }
    });
  }

  getCountry(countryId) {
      this.countryService.getOne(countryId).subscribe(response =>
        {
          this.country = response;
          this.country.id = countryId;
          this.form.hide();
        }
      );
  }

  goBack() {
    this.location.back();
  }

  onSubmit() {
    this.form.show();
    // this.city.countryId = 1;
    this.countryService.submit(this.country).subscribe(
      (response: any) => {
        this.toastr.success('Uspješno uneseno');
        this.router.navigate(['countries']);
        this.form.hide();
      },
      (response: any) => {
        const firstError = response.error.errors;
        const firstKey = Object.keys(firstError)[0];
        this.errorMessage = firstError[firstKey][0];
        this.form.hide();
      });
  }

}


