import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CityService } from '../city.service';
import { ToastrService } from 'ngx-toastr';
import { FormService } from 'src/app/shared/form.service';
import { CountryService } from 'src/app/country/country.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-city-form',
  templateUrl: './city-form.component.html',
  styleUrls: ['./city-form.component.scss']
})
export class CityFormComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private cityService: CityService,
    private router: Router,
    private toastr: ToastrService,
    private form: FormService,
    private countryService: CountryService,
    private location: Location
  ) { }

  public city: any = {};
  public countries: any = [];
  public errorMessage = '';
  public selectedCountryId: any = {};


  ngOnInit() {
    this.route.params.subscribe(params => {
      const cityId = params.id;
      this.getCountries();
      if(cityId != null) {
        this.getCity(cityId);
      }
    });
  }

  getCity(cityId) {
      this.cityService.getOne(cityId).subscribe(response =>
        {
          this.city = response;
          this.city.id = cityId;
          this.selectedCountryId = this.city.countryId;
          this.form.hide();
        }
      );
  }


  onSubmit() {
    this.form.show();
    this.selectedCountryId = this.city.countryId;
    // this.city.countryId = 1;
    this.cityService.submit(this.city).subscribe(
      (response: any) => {
        this.toastr.success('Uspješno uneseno');
        this.router.navigate(['cities']);
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
    this.toastr.warning('Nije uneseno');
  }
  getCountries() {
    this.countryService.getAll().subscribe((response: any) => {
      this.countries = response.response.data;
    }
    );
  }

}

