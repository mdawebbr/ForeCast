import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ParameterAllSetupComponent } from './parameter-all-setup.component';

describe('ParameterAllSetupComponent', () => {
  let component: ParameterAllSetupComponent;
  let fixture: ComponentFixture<ParameterAllSetupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ParameterAllSetupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ParameterAllSetupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
