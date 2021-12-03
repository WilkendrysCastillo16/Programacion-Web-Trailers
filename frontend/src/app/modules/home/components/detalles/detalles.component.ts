import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ITraillerActor } from '../../interfaces/trailler-actor';
import { IActor } from './../../interfaces/actor';
import { PrincipalComponent } from '../../pages/principal/principal.component';
import { DomSanitizer } from '@angular/platform-browser';
import { ApiService } from 'src/app/shared/services/api/api.service';
import { Router } from '@angular/router';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'app-detalles',
  templateUrl: './detalles.component.html',
  styleUrls: ['./detalles.component.css']
})
export class DetallesComponent implements OnInit {
  
  trailer!: ITraillerActor;
  actor!: IActor;

  constructor(public sanitizer: DomSanitizer, public dialogRef: MatDialogRef<DetallesComponent>, private api:ApiService,
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

  deleteTrailler(){
    this.api.deleteTraillers(this.detalle.trailer.trailler.id).subscribe(resp=>{
      console.log(resp);
    });   
    setTimeout(() => 
    {
      location.reload();
    },400);
    
  }

}

