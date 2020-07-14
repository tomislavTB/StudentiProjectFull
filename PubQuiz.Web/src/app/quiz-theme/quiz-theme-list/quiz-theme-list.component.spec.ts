import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuizThemeListComponent } from './quiz-theme-list.component';

describe('QuizThemeListComponent', () => {
  let component: QuizThemeListComponent;
  let fixture: ComponentFixture<QuizThemeListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuizThemeListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuizThemeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
