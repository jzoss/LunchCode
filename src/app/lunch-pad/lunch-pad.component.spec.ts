import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LunchPadComponent } from './lunch-pad.component';

describe('LunchPadComponent', () => {
  let component: LunchPadComponent;
  let fixture: ComponentFixture<LunchPadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LunchPadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LunchPadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
