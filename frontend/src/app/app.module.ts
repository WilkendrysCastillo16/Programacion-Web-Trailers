import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DirectivefirstDirective } from './shared/directives/directivefirst.directive';
// import { PipefirstPipe } from './shared/pipes/pipefirst.pipe';
import { HomeModule } from './modules/home/home.module';
// import { FooterComponent } from './core/footer/footer.component';//importamos el footer para su acceso
// import { HeaderComponent } from './core/header/header.component';//importamos el header para su acceso
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';//de angular material
import { ReactiveFormsModule, FormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    DirectivefirstDirective
    // PipefirstPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HomeModule,
    HttpClientModule,
    ReactiveFormsModule, 
    FormsModule
    // FooterComponent,
    // HeaderComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
