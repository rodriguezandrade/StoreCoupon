import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerAddUpdateComponent } from './owner-add-update.component';

describe('OwnerAddUpdateComponent', () => {
  let component: OwnerAddUpdateComponent;
  let fixture: ComponentFixture<OwnerAddUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OwnerAddUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OwnerAddUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
