import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudTrailersComponent } from './crud-trailers.component';

describe('CrudTrailersComponent', () => {
  let component: CrudTrailersComponent;
  let fixture: ComponentFixture<CrudTrailersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CrudTrailersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudTrailersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
