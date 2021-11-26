import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DirectivefirstDirective } from './shared/directives/directivefirst.directive';
import { PipefirstPipe } from './shared/pipes/pipefirst.pipe';

import { FooterComponent } from './core/footer/footer.component';//importamos el footer para su acceso
import { HeaderComponent } from './core/header/header.component';//importamos el header para su acceso

@NgModule({
  declarations: [
    AppComponent,
    DirectivefirstDirective,
    PipefirstPipe,
    FooterComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
