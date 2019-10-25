import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AltaPrendaComponent } from './alta-prenda.component';

describe('AltaPrendaComponent', () => {
  let component: AltaPrendaComponent;
  let fixture: ComponentFixture<AltaPrendaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AltaPrendaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AltaPrendaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
