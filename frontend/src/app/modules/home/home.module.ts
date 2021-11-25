import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavComponent } from './components/nav/nav.component';
import { LoginComponent } from './pages/login/login.component';



@NgModule({
  declarations: [
    NavComponent,
    LoginComponent
  ],
  imports: [
    CommonModule
  ]
})
export class HomeModule { }
