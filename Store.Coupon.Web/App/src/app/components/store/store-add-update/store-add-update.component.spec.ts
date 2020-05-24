import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreAddUpdateComponent } from './store-add-update.component';

describe('StoreAddUpdateComponent', () => {
  let component: StoreAddUpdateComponent;
  let fixture: ComponentFixture<StoreAddUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StoreAddUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StoreAddUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
