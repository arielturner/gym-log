import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditBodyPartComponent } from './add-edit-body-part.component';

describe('AddEditBodyPartComponent', () => {
  let component: AddEditBodyPartComponent;
  let fixture: ComponentFixture<AddEditBodyPartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddEditBodyPartComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditBodyPartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
