import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SugerenciasComponent } from './sugerencias.component';

describe('SugerenciasComponent', () => {
  let component: SugerenciasComponent;
  let fixture: ComponentFixture<SugerenciasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SugerenciasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SugerenciasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
