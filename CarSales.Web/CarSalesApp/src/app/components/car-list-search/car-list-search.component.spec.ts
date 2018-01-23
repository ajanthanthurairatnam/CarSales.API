import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarListSearchComponent } from './car-list-search.component';

describe('CarListSearchComponent', () => {
  let component: CarListSearchComponent;
  let fixture: ComponentFixture<CarListSearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarListSearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarListSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
