import { Component, OnInit, Inject } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { SnackDetail} from '../snack-detail';
import { CurdSnackDetailServiceService } from '../services/curd-snack-detail-service/curd-snack-detail-service.service';

@Component({
  selector: 'app-curd-snack-dialog',
  templateUrl: './curd-snack-dialog.component.html',
  styleUrls: ['./curd-snack-dialog.component.css']
})
export class CurdSnackDialogComponent implements OnInit {
  public detail: SnackDetail = new SnackDetail();

  constructor(private dialogRef: MatDialogRef<CurdSnackDialogComponent>,
              private detailService: CurdSnackDetailServiceService,
              @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.detailService.getCurdSnackDetail(this.data.id).subscribe(response => {
      if(response){
        this.detail = response;
      }
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
