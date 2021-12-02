import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ITraillerActor } from '../../interfaces/trailler-actor';
import { IActor } from './../../interfaces/actor';
import { PrincipalComponent } from '../../pages/principal/principal.component';

@Component({
  selector: 'app-detalles',
  templateUrl: './detalles.component.html',
  styleUrls: ['./detalles.component.css']
})
export class DetallesComponent implements OnInit {
  
  trailer!: ITraillerActor;
  actor!: IActor;

  constructor(public dialogRef: MatDialogRef<PrincipalComponent>,@Inject(MAT_DIALOG_DATA) public detalle: {trailer: ITraillerActor}) { }

  ngOnInit(): void {
    console.log(this.detalle);
  }

  onHome(): void {
    this.dialogRef.close();
  }

}
