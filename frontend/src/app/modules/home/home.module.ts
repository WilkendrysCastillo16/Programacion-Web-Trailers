// import { MatSliderModule } from '@angular/material/slider';
// import { MatSelectModule } from '@angular/material/select';
// import { MatDatepickerModule } from '@angular/material/datepicker';
// import { MatStepperModule } from '@angular/material/stepper';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './pages/login/login.component';
import { DetallesComponent } from './components/detalles/detalles.component';
import { PrincipalComponent } from './pages/principal/principal.component';
import { MaterialModule } from './material/material.module';
import { EquipoComponent } from './pages/equipo/equipo.component';
import { DialogComponent } from './components/dialog/dialog.component';
import { CrudTrailersComponent } from './pages/crud-trailers/crud-trailers.component';
import { HeaderComponent } from 'src/app/core/header/header.component';
import { FooterComponent } from './../../core/footer/footer.component';
import { FiltroPipe } from './filtro.pipe';


@NgModule({
  declarations: [
    LoginComponent,
    DetallesComponent,
    PrincipalComponent,
    EquipoComponent,
    DialogComponent,
    CrudTrailersComponent,
    HeaderComponent,
    FooterComponent,
    FiltroPipe
    // MatStepperModule,
    // MatDatepickerModule,
    // MatSelectModule,
    // MatSliderModule
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  entryComponents:[CrudTrailersComponent]
})
export class HomeModule { }
