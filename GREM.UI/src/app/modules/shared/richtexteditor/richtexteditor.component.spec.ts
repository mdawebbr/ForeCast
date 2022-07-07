import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RichtexteditorComponent } from './richtexteditor.component';

describe('RichtexteditorComponent', () => {
  let component: RichtexteditorComponent;
  let fixture: ComponentFixture<RichtexteditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RichtexteditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RichtexteditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
