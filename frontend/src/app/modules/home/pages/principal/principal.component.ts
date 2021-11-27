import { DialogComponent } from './../../components/dialog/dialog.component';
import { CrudTrailersComponent } from './../crud-trailers/crud-trailers.component';
import { DetallesComponent } from './../../components/detalles/detalles.component';
import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
//import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.css']
})
export class PrincipalComponent implements OnInit {

  constructor(public dialog: MatDialog) { }

  openDialog() {
    const dialogRef = this.dialog.open(DetallesComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
  openAdmin(){
    const dialogConfig= new MatDialogConfig();
    dialogConfig.disableClose = false;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "70%";
    dialogConfig.width = "70%";
    const dialogAdmin = this.dialog.open(CrudTrailersComponent,dialogConfig);
    // const dialogAdmin = this.dialog.open(DialogComponent);
  }
  ngOnInit(): void {
  }
  
}
