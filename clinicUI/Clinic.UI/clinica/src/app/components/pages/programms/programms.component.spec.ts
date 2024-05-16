import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProgrammsComponent } from './programms.component';

describe('ProgrammsComponent', () => {
  let component: ProgrammsComponent;
  let fixture: ComponentFixture<ProgrammsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProgrammsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProgrammsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
