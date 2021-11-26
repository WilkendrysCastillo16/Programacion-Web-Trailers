import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//AQUI SE DEBERAN IMPORTAR TODO LO QUE TENGA QUE VER CON ANGULAR MATERIAL

import {MatCardModule} from '@angular/material/card';//para las card de material
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule
  ],
  exports:[
    MatCardModule,
    MatButtonModule,
    MatIconModule
  ]
})
export class MaterialModule { }
