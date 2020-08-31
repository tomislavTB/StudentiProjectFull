import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormService } from 'src/app/shared/form.service';
import { Pagination } from 'src/app/shared/Response/Pagination';
import { ChampionService } from '../champion.service';
import { ChampionFormComponent } from '../champion-form/champion-form.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NgxDatatablePageLimitEnum } from 'src/app/shared/ngx-datatable-page-limit.enum';

@Component({
  selector: 'app-champion-list',
  templateUrl: './champion-list.component.html',
  styleUrls: ['./champion-list.component.scss']
})
export class ChampionListComponent implements OnInit{


  constructor(private championService: ChampionService, private toastr: ToastrService, private router: Router, private form: FormService, private ngbModalService: NgbModal,
    ) { }

  fullChampions: any;
  private champions = [];
  public pagination: Pagination;
  public currentPage: number = 1;
  user: any;
  admin: any;

  ngOnInit() {
    this.getChampions();
    if(JSON.parse(localStorage.getItem('auth_user'))){
      this.user = JSON.parse(localStorage.getItem('auth_user'))
      if(this.user){
        if(this.user.admin == true){
          this.admin = true;
        }
        else{
          this.admin = false;
        }
        
      }
    }

  }

  getChampions()
  { this.championService.getAll().subscribe((response: any) => {
   const Champion = [];
      
   this.champions = response.response.data;
   if(this.champions && this.champions.length > 0){
     this.champions.forEach(row => {
      Champion.push({
           'id': row.id,
           'organizator': row.authUser,
           'name': row.noticeBoard.name,
           'dateWhen': row.noticeBoard.dateWhen,
           'champion': row.name
       });
       
    }  
    
 );
 this.fullChampions = [...Champion]; 
   }
   
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


onEdit(row) {
  // this.form.show();
  const modalRef = this.ngbModalService.open(ChampionFormComponent, { size: 'lg', backdrop: 'static', keyboard: false});
    if(row) {
    modalRef.componentInstance.row = row;
  }
  modalRef.result.then(result => {
    if (result == 'ok') {
      this.getChampions();
    }
    }).catch((res) => {});
  
}

onAdd() {
  // this.form.show();
  const modalRef = this.ngbModalService.open(ChampionFormComponent, { size: 'lg', backdrop: 'static', keyboard: false});
  modalRef.result.then(result => {
    if (result == 'ok') {
      this.getChampions();
    }
    }).catch((res) => {});
    
}
get pageLimit() {
  return NgxDatatablePageLimitEnum.limit;
}
}
