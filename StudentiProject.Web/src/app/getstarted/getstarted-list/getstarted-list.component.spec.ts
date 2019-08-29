import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetstartedListComponent } from './getstarted-list.component';

describe('GetstartedListComponent', () => {
  let component: GetstartedListComponent;
  let fixture: ComponentFixture<GetstartedListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetstartedListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetstartedListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
