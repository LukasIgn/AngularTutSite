import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CurdSnackService } from '../services/curd-snack-service/curd-snack.service';
import { MatSort, MatPaginator, MatTableDataSource, MatDialog, MatDialogConfig} from '@angular/material';
import { Snack } from '../snack';
import { CurdSnackDialogComponent } from '../curd-snack-dialog/curd-snack-dialog.component';
import { SnackDetail} from '../snack-detail';

@Component({
  selector: 'app-create-curd-snack',
  templateUrl: './create-curd-snack.component.html',
  styleUrls: ['./create-curd-snack.component.css']
})
export class CreateCurdSnackComponent implements OnInit {
  registerForm: FormGroup;
  submitted = false;
  dataSource = new MatTableDataSource([]);
  displayedColumns = ['id', 'name', 'email', 'type'];
  editableDataCollection = [];
  details: SnackDetail;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(CurdSnackDialogComponent) detais: CurdSnackDialogComponent;

  constructor(private formBuilder: FormBuilder,
              private route: ActivatedRoute,
              private service: CurdSnackService,
              public dialog: MatDialog) { }

  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;

    this.registerForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      name: ['', Validators.required],
      type: ['', Validators.required]
    });

    this.service.getCurdSnacks().subscribe(
      response => {
        this.dataSource = new MatTableDataSource(response);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }
    );
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }

  onChange(row: Snack){
    if(!this.editableDataCollection.includes(row.id)){
      this.editableDataCollection.push(row.id);
    }
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }

    var data = this.registerForm.value;

    this.service.postCurdSnacks(this.registerForm.value).subscribe( response => {
      this.service.getCurdSnacks().subscribe(
        response => {
          this.dataSource = new MatTableDataSource(response);
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
        }
      );
    });
  }

  onEditTable(){
    var editableList = this.dataSource.filteredData.filter(item => {
      if(this.editableDataCollection.includes(item.id)){
        return item;
      }
    })
    this.service.putCurdSnacks(editableList).subscribe();
  }

  openDetail(id): void {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = false;
    dialogConfig.autoFocus = true;
    dialogConfig.data = {id: id};

    const dialogRef = this.dialog.open(CurdSnackDialogComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.details = result;
    });
  }
}