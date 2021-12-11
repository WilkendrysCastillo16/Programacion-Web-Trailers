import { MaterialModule } from './../modules/home/material/material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
//import {MatInputModule} from '@angular/material/input';


@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
    //MatInputModule
  ]
})
export class CoreModule { }
