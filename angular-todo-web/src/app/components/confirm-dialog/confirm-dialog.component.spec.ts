import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmGroupDialogComponent } from './confirm-dialog.component';

describe('ConfirmGroupDialogComponent', () => {
  let component: ConfirmGroupDialogComponent;
  let fixture: ComponentFixture<ConfirmGroupDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ConfirmGroupDialogComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmGroupDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
