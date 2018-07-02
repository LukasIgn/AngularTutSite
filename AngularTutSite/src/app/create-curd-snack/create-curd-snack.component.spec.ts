import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCurdSnackComponent } from './create-curd-snack.component';

describe('CreateCurdSnackComponent', () => {
  let component: CreateCurdSnackComponent;
  let fixture: ComponentFixture<CreateCurdSnackComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateCurdSnackComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateCurdSnackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
