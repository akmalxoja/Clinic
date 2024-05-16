import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiplomsComponent } from './diploms.component';

describe('DiplomsComponent', () => {
  let component: DiplomsComponent;
  let fixture: ComponentFixture<DiplomsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DiplomsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DiplomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
