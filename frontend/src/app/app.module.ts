import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DirectivefirstDirective } from './shared/directives/directivefirst.directive';
import { PipefirstPipe } from './shared/pipes/pipefirst.pipe';

import { HomeModule } from './modules/home/home.module';
// import { FooterComponent } from './core/footer/footer.component';//importamos el footer para su acceso
// import { HeaderComponent } from './core/header/header.component';//importamos el header para su acceso
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';//de angular material

@NgModule({
  declarations: [
    AppComponent,
    DirectivefirstDirective,
    PipefirstPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HomeModule
    // FooterComponent,
    // HeaderComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
