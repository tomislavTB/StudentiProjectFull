import { Component, OnInit } from '@angular/core';
import { HomeService } from '../home.service';

@Component({
  selector: 'app-home-list',
  templateUrl: './home-list.component.html',
  styleUrls: ['./home-list.component.scss']
})
export class HomeListComponent implements OnInit {

  constructor(private gradeService: HomeService
    ) { }

    private homes = [];

    ngOnInit() {
      this.gradeService.getAll().subscribe((response: any) => {
        this.homes = response;
    });
  }

}
