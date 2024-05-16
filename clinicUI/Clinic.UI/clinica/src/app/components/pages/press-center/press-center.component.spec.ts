import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PressCenterComponent } from './press-center.component';

describe('PressCenterComponent', () => {
  let component: PressCenterComponent;
  let fixture: ComponentFixture<PressCenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PressCenterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PressCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
