import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyPartsPageComponent } from './body-parts-page.component';

describe('BodyPartsPageComponent', () => {
  let component: BodyPartsPageComponent;
  let fixture: ComponentFixture<BodyPartsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BodyPartsPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BodyPartsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
