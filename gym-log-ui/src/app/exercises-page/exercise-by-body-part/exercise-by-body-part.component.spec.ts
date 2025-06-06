import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseByBodyPartComponent } from './exercise-by-body-part.component';

describe('ExerciseByBodyPartComponent', () => {
  let component: ExerciseByBodyPartComponent;
  let fixture: ComponentFixture<ExerciseByBodyPartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExerciseByBodyPartComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExerciseByBodyPartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
