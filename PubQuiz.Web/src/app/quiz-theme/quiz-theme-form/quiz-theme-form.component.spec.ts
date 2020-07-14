import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuizThemeFormComponent } from './quiz-theme-form.component';

describe('QuizThemeFormComponent', () => {
  let component: QuizThemeFormComponent;
  let fixture: ComponentFixture<QuizThemeFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuizThemeFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuizThemeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
