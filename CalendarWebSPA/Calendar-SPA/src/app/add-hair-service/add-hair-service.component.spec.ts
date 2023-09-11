import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddHairServiceComponent } from './add-hair-service.component';

describe('AddHairServiceComponent', () => {
  let component: AddHairServiceComponent;
  let fixture: ComponentFixture<AddHairServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddHairServiceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddHairServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
