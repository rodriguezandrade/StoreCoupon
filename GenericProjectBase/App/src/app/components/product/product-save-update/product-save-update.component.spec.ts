import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductSaveUpdateComponent } from './product-save-update.component';

describe('ProductSaveUpdateComponent', () => {
  let component: ProductSaveUpdateComponent;
  let fixture: ComponentFixture<ProductSaveUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductSaveUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductSaveUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
