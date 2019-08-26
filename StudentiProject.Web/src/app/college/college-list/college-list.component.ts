import { Component, OnInit } from '@angular/core';
import { CollegeService } from '../college.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormService } from 'src/app/shared/form.service';
import { Pagination } from 'src/app/shared/Response/Pagination';

@Component({
  selector: 'app-college-list',
  templateUrl: './college-list.component.html',
  styleUrls: ['./college-list.component.scss']
})
export class CollegeListComponent implements OnInit {

  constructor(private collegeService: CollegeService, private toastr: ToastrService, private router: Router, private form: FormService
    ) { }

    private colleges = [];
    public pagination: Pagination;
    public currentPage: number = 1;


    ngOnInit() {
     this.getColleges();
  }

  getColleges() {
    this.collegeService
    .getPage(this.currentPage)
    .subscribe(({ data, pagination }) =>  {
    this.colleges = data;
    this.pagination = pagination;
  });

  }

  onDelete(collegeId) {
    if (confirm('Da li ste sigurni?')) {
      this.collegeService.deleteOne(collegeId).subscribe(result => {
        this.collegeService.getAll();
        this.toastr.success('Izbrisali ste fakultet.');
        this.getColleges();
   });
 }
}

nextPage() {
  this.currentPage++;
  this.getColleges();
}

prevPage() {
  if(this.currentPage <= 1) {
    this.currentPage = 1;
  } else {
    this.currentPage--;
  }

  this.getColleges();
}

onAdd() {
   this.router.navigate(['colleges/new']);
}

onEdit(collegeId) {
  this.form.show();
  this.router.navigate(['colleges', collegeId]);
}
}

