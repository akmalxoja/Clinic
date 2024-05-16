import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DurationTimeComponent } from './duration-time.component';

describe('DurationTimeComponent', () => {
  let component: DurationTimeComponent;
  let fixture: ComponentFixture<DurationTimeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DurationTimeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DurationTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
