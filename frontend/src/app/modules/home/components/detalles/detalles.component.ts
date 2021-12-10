import { ITrailer } from './../../interfaces/trailer';
import { CrudTrailersComponent } from './../../pages/crud-trailers/crud-trailers.component';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ITraillerActor } from '../../interfaces/trailler-actor';
import { IActor } from './../../interfaces/actor';
import { PrincipalComponent } from '../../pages/principal/principal.component';
import { DomSanitizer } from '@angular/platform-browser';
import { ApiService } from 'src/app/shared/services/api/api.service';
import { Router } from '@angular/router';
import { delay } from 'rxjs/operators';

import Swal from 'sweetalert2';


@Component({
  selector: 'app-detalles',
  templateUrl: './detalles.component.html',
  styleUrls: ['./detalles.component.css']
})
export class DetallesComponent implements OnInit {
  
  trailer!: ITraillerActor;
  actor!: IActor;

  constructor(private dialog: MatDialog,public sanitizer: DomSanitizer, public dialogRef: MatDialogRef<DetallesComponent>, private api:ApiService,
    @Inject(MAT_DIALOG_DATA) public detalle: {trailer: ITraillerActor}, private router: Router) { }

  ngOnInit(): void {
    
    console.log(this.detalle);
  }

  onClose(): void {
    this.dialogRef.close();
  }

  adminExiste(){
    if(localStorage.getItem("Token")){
      return true;
    }
    return false;
  }

  onEdit(trailer:any){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = trailer;
    this.dialog.open(CrudTrailersComponent, dialogConfig);
    this.dialogRef.close();
    console.log(trailer);
  }

  deleteTrailler(){
    Swal.fire({
      title: 'Estas seguro?',
      text: "Una vez eliminado no se podra recuperar!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Borrar Trailer'
    }).then((result) => {
      if (result.isConfirmed) {
        this.api.deleteTraillers(this.detalle.trailer.trailler.id).subscribe(resp=>{
          console.log(resp);
        });   
        setTimeout(() => 
        {
          location.reload();
        },500);
        Swal.fire({
          icon: 'success',
          title: 'Trailler eliminado correctamente',
          showConfirmButton: false,
          timer: 1000
        }) 
      }else{
        Swal.fire("No se elimino el trailer!");
      }
    });
  }

}

