import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './pages/login/login.component';
import { DetallesComponent } from './components/detalles/detalles.component';



@NgModule({
  declarations: [
    LoginComponent,
    DetallesComponent
  ],
  imports: [
    CommonModule
  ]
})
export class HomeModule {}
