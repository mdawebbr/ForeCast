import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangelogmasterComponent } from './changelogmaster.component';

describe('ChangelogmasterComponent', () => {
  let component: ChangelogmasterComponent;
  let fixture: ComponentFixture<ChangelogmasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChangelogmasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChangelogmasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
