import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DirectivefirstDirective } from './shared/directives/directivefirst.directive';
import { PipefirstPipe } from './shared/pipes/pipefirst.pipe';

@NgModule({
  declarations: [
    AppComponent,
    DirectivefirstDirective,
    PipefirstPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
