import { ITraillerActor } from './../../interfaces/trailler-actor';
import { IActor } from './../../interfaces/actor';
import { ApiService } from './../../../../shared/services/api/api.service';
import { HeaderComponent } from './../../../../core/header/header.component';
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

  trailerActor:ITraillerActor[]|undefined;

  constructor(public dialog: MatDialog, private api:ApiService) { }

  onDetails(trailer:ITraillerActor) {
    // const dialogRef = this.dialog.open(DetallesComponent);

    // dialogRef.afterClosed().subscribe(result => {
    //   console.log(`Dialog result: ${result}`);
    // });
    const dialogConfig= new MatDialogConfig();
    dialogConfig.data = { trailer };
    const dialogAdmin = this.dialog.open(DetallesComponent, dialogConfig);
  }
  openAdmin(){
    // const dialogConfig= new MatDialogConfig();
    // dialogConfig.disableClose = false;
    // dialogConfig.autoFocus = true;
    // dialogConfig.width = "70%";
    // dialogConfig.width = "70%";
    // const dialogAdmin = this.dialog.open(CrudTrailersComponent,dialogConfig);
    const dialogAdmin = this.dialog.open(CrudTrailersComponent);
    // const dialogAdmin = this.dialog.open(DialogComponent);
  }
  ngOnInit(): void {
    this.api.getTraillerActor().subscribe(x=>{
      // console.log(x)
      this.trailerActor = x.result;
      this.trailerActor?.reverse();
      //console.log(this.trailerActor);
    })
  }
  
  adminExiste(){
    if(localStorage.getItem("Token")){
      return true;
    }
    return false;
  }

  // editar(){
  //   const dialogAdmin = this.dialog.open(CrudTrailersComponent);
  // }
  
}
