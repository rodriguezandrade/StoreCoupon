import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubCategoryAddUpdateComponent } from './sub-category-add-update.component';

describe('SubCategoryAddUpdateComponent', () => {
  let component: SubCategoryAddUpdateComponent;
  let fixture: ComponentFixture<SubCategoryAddUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubCategoryAddUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubCategoryAddUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
