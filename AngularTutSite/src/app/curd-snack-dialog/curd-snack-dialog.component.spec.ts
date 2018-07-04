import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CurdSnackDialogComponent } from './curd-snack-dialog.component';

describe('CurdSnackDialogComponent', () => {
  let component: CurdSnackDialogComponent;
  let fixture: ComponentFixture<CurdSnackDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurdSnackDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurdSnackDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
