import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AcessonegadoComponent } from './acessonegado.component';

describe('AcessonegadoComponent', () => {
  let component: AcessonegadoComponent;
  let fixture: ComponentFixture<AcessonegadoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AcessonegadoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AcessonegadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
