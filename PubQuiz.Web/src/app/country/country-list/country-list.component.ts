import { Component, OnInit } from '@angular/core';
import { CountryService } from '../country.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormService } from 'src/app/shared/form.service';
import { Pagination } from 'src/app/shared/Response/Pagination';
import { NgxDatatablePageLimitEnum } from 'src/app/shared/ngx-datatable-page-limit.enum';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.scss']
})
export class CountryListComponent implements OnInit {

  constructor(private countryService: CountryService, private toastr: ToastrService, private router: Router, private form: FormService
    ) { }
    newCountries: any;
    login: any;
    private countries = [];
    public pagination: Pagination;
    public currentPage: number = 1;

    ngOnInit() {
      this.getCountries();
      this.login = localStorage.getItem('auth_user')
  }

  getCountries() {
    this.countryService
    .getAll()
    .subscribe((response: any) =>  {
    const myCities = [];
    this.countries = response.response.data;
    if(this.countries && this.countries.length > 0){
      this.countries.forEach(row => {
        myCities.push({
            'id': row.id,
            'name': row.name,
        });
        
     }  
     
  );
  this.newCountries = [...myCities]; 
    }
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


// nextPage() {
//   this.currentPage++;
//   this.getCountries();
// }

// prevPage() {
//   if(this.currentPage <= 1) {
//     this.currentPage = 1;
//   } else {
//     this.currentPage--;
//   }

//   this.getCountries();
// }


onAdd() {
   this.router.navigate(['countries/new']);
}

onEdit(countryId) {
  this.form.show();
  this.router.navigate(['countries', countryId]);
}

get pageLimit() {
  return NgxDatatablePageLimitEnum.limit;
}
}
