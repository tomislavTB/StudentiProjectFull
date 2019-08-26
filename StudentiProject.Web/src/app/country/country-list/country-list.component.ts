import { Component, OnInit } from '@angular/core';
import { CountryService } from '../country.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormService } from 'src/app/shared/form.service';
import { Pagination } from 'src/app/shared/Response/Pagination';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.scss']
})
export class CountryListComponent implements OnInit {

  constructor(private countryService: CountryService, private toastr: ToastrService, private router: Router, private form: FormService
    ) { }

    private countries = [];
    public pagination: Pagination;
    public currentPage: number = 1;

    ngOnInit() {
      this.getCountries();
  }

  getCountries() {
    this.countryService
    .getPage(this.currentPage)
    .subscribe(({ data, pagination }) =>  {
    this.countries = data;
    this.pagination = pagination;
  });

  }


  onDelete(countryId) {
    if (confirm('Da li ste sigurni?')) {
      this.countryService.deleteOne(countryId).subscribe(result => {
        this.countryService.getAll();
        this.toastr.success('Izbrisali ste državu.');
        this.getCountries();
   });
 }
}


nextPage() {
  this.currentPage++;
  this.getCountries();
}

prevPage() {
  if(this.currentPage <= 1) {
    this.currentPage = 1;
  } else {
    this.currentPage--;
  }

  this.getCountries();
}


onAdd() {
   this.router.navigate(['countries/new']);
}

onEdit(countryId) {
  this.form.show();
  this.router.navigate(['countries', countryId]);
}


}
