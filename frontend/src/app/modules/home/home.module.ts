import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './pages/login/login.component';
import { DetallesComponent } from './components/detalles/detalles.component';
import { EquipoComponent } from './pages/equipo/equipo.component';



@NgModule({
  declarations: [
    LoginComponent,
    DetallesComponent,
    EquipoComponent
  ],
  imports: [
    CommonModule
  ]
})
export class HomeModule {}
