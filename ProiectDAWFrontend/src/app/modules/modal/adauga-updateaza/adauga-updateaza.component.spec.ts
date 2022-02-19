import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdaugaUpdateazaComponent } from './adauga-updateaza.component';

describe('AdaugaUpdateazaComponent', () => {
  let component: AdaugaUpdateazaComponent;
  let fixture: ComponentFixture<AdaugaUpdateazaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdaugaUpdateazaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdaugaUpdateazaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
