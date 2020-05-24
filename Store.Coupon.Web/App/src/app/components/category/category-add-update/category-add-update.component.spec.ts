import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryAddUpdateComponent } from './category-add-update.component';

describe('CategoryAddUpdateComponent', () => {
  let component: CategoryAddUpdateComponent;
  let fixture: ComponentFixture<CategoryAddUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CategoryAddUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryAddUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
