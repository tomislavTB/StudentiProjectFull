import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CityService } from '../city.service';
import { FormService } from 'src/app/shared/form.service';
import { Pagination } from 'src/app/shared/Response/Pagination';

@Component({
  selector: 'app-city-list',
  templateUrl: './city-list.component.html',
  styleUrls: ['./city-list.component.scss']
})
export class CityListComponent implements OnInit {


  constructor(private cityService: CityService, private toastr: ToastrService, private router: Router, private form: FormService
    ) { }

  private cities = [];
  public pagination: Pagination;
  public currentPage: number = 1;

  ngOnInit() {
    this.getCities();

  }

  getCities() {
    this.cityService
    .getPage(this.currentPage)
    .subscribe(({ data, pagination }) =>  {
    this.cities = data;
    this.pagination = pagination;
  });

  }



  onDelete(cityId) {
    if (confirm('Da li ste sigurni?')) {
      this.cityService.deleteOne(cityId).subscribe(result => {
        this.cityService.getAll();
        this.toastr.success('Izbrisali ste grad.');
        this.getCities();
   });
 }
}

nextPage() {
  this.currentPage++;
  this.getCities();
}

prevPage() {
  if(this.currentPage <= 1) {
    this.currentPage = 1;
  } else {
    this.currentPage--;
  }

  this.getCities();
}

onAdd() {
   this.router.navigate(['cities/new']);
}

onEdit(cityId) {
  this.form.show();
  this.router.navigate(['cities', cityId]);
}
}
