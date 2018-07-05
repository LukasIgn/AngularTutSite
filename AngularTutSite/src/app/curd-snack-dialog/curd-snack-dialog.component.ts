import { Component, OnInit, Inject } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { SnackDetail} from '../snack-detail';

@Component({
  selector: 'app-curd-snack-dialog',
  templateUrl: './curd-snack-dialog.component.html',
  styleUrls: ['./curd-snack-dialog.component.css']
})
export class CurdSnackDialogComponent implements OnInit {

  detail: SnackDetail = new SnackDetail();
  constructor(private dialogRef: MatDialogRef<CurdSnackDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.detail = this.data;
  }

  onNoClick(): void {
    const closeIdentity = { dontSave: true }
    this.dialogRef.close(closeIdentity);
  }
}
