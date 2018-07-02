import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCurdSnackComponent } from './edit-curd-snack.component';

describe('EditCurdSnackComponent', () => {
  let component: EditCurdSnackComponent;
  let fixture: ComponentFixture<EditCurdSnackComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditCurdSnackComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCurdSnackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
