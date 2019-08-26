import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExecutorListComponent } from './executor-list.component';

describe('ExecutorListComponent', () => {
  let component: ExecutorListComponent;
  let fixture: ComponentFixture<ExecutorListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExecutorListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExecutorListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
