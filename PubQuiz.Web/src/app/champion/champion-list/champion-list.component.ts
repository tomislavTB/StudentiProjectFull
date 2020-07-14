import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormService } from 'src/app/shared/form.service';
import { Pagination } from 'src/app/shared/Response/Pagination';
import { ChampionService } from '../champion.service';

@Component({
  selector: 'app-champion-list',
  templateUrl: './champion-list.component.html',
  styleUrls: ['./champion-list.component.scss']
})
export class ChampionListComponent implements OnInit{


  constructor(private championService: ChampionService, private toastr: ToastrService, private router: Router, private form: FormService
    ) { }

  private champions = [];
  public pagination: Pagination;
  public currentPage: number = 1;

  ngOnInit() {
    this.getChampions();

  }

  getChampions()
  { this.championService.getAll().subscribe((response: any) => {
   this.champions = response.response.data;
   console.log(this.champions);
   
});
}



  onDelete(championId) {
    if (confirm('Da li ste sigurni?')) {
      this.championService.deleteOne(championId).subscribe(result => {
        this.championService.getAll();
        this.toastr.success('Izbrisali ste pobjednika.');
        this.getChampions();
   });
 }
}

nextPage() {
  this.currentPage++;
  this.getChampions();
}

prevPage() {
  if(this.currentPage <= 1) {
    this.currentPage = 1;
  } else {
    this.currentPage--;
  }

  this.getChampions();
}

onAdd() {
   this.router.navigate(['champions/new']);
}

onEdit(championId) {
  this.form.show();
  this.router.navigate(['champions', championId]);
}
}
