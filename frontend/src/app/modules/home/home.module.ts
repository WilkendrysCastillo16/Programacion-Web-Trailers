import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './pages/login/login.component';
import { DetallesComponent } from './components/detalles/detalles.component';
import { PrincipalComponent } from './pages/principal/principal.component';
import { MaterialModule } from './material/material.module';
import { EquipoComponent } from './pages/equipo/equipo.component';



@NgModule({
  declarations: [
    LoginComponent,
    DetallesComponent,
    PrincipalComponent,
    EquipoComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ]
})
export class HomeModule {}