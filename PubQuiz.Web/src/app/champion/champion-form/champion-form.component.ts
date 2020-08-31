import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ChampionService } from '../champion.service';
import { ToastrService } from 'ngx-toastr';
import { FormService } from 'src/app/shared/form.service';
import { UserService } from 'src/app/users/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { QuizzesService } from 'src/app/quizzes/quizzes.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-champion-form',
  templateUrl: './champion-form.component.html',
  styleUrls: ['./champion-form.component.scss']
})
export class ChampionFormComponent implements OnInit, OnDestroy {

  @Input() row;


  constructor(
    private route: ActivatedRoute,
    private championService: ChampionService,
    private router: Router,
    private toastr: ToastrService,
    private form: FormService,
    private location: Location,
    private formBuilder: FormBuilder,
    public modal: NgbActiveModal,
    private quizzesService: QuizzesService, 
  ) { }
  ngOnDestroy(): void {
  }

  public quizzes: any = {};
  public errorMessage = '';
  fullChampions: any;
  id: number;



  ChampionGroup: FormGroup = this.formBuilder.group({
    noticeBoardId: [null, Validators.required],
    name: ['', Validators.required],
  });


  ngOnInit() {
    this.getQuzzzes();

    
    if(this.row){
     this.championService.getAll().subscribe((response: any) => {
      let selectedChampions = response.response.data.find(x => x.id === this.row.id);

      
      this.ChampionGroup.patchValue({
        noticeBoardId: selectedChampions.noticeBoard.id,
        name: selectedChampions.name,
      })
      this.id = selectedChampions.id
  });

    }
  }

  getQuzzzes()
  { this.quizzesService.getAll().subscribe((response: any) => {    
   this.quizzes = response.response.data;
   
   
});
}

goBack() {
  this.modal.close()
  this.toastr.warning('Nije uneseno');
}

onSubmit() {
  this.form.show();
  // this.city.countryId = 1;
  if(this.row){
    this.championService.submit(this.ChampionGroup.value,true, this.id).subscribe(
      (response: any) => {
        this.toastr.success('Uspješno uneseno');
        this.modal.close('ok')
        this.form.hide();
      },
      (response: any) => {
        const firstError = response.error.errors;
        const firstKey = Object.keys(firstError)[0];
        this.errorMessage = firstError[firstKey][0];
        this.form.hide();
      });
  }
  else{

    this.championService.submit(this.ChampionGroup.value, false, this.id).subscribe(
      (response: any) => {
        this.toastr.success('Uspješno uneseno');
        this.modal.close('ok')
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
}
