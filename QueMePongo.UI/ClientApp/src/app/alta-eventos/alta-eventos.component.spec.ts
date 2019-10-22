import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AltaEventosComponent } from './alta-eventos.component';

describe('AltaEventosComponent', () => {
  let component: AltaEventosComponent;
  let fixture: ComponentFixture<AltaEventosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AltaEventosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AltaEventosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
