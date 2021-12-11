import { CrudTrailersComponent } from './modules/home/pages/crud-trailers/crud-trailers.component';
import { PrincipalComponent } from './modules/home/pages/principal/principal.component';
import { EquipoComponent } from './modules/home/pages/equipo/equipo.component';
//import { HeaderComponent } from './core/header/header.component';
import { DetallesComponent } from './modules/home/components/detalles/detalles.component';
import { LoginComponent } from './modules/home/pages/login/login.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GuardfirstGuard } from './core/guards/guardfirst.guard';

//dentro de este arreglo se debe agregar la ruta que se desea visualizar en donde debera contener 
//un path para ser accedido y el nombre del componente. En dado caso de tener guards para ser protegido
//se haria como en la linea 10
const routes: Routes = [
  {path:'login',component:LoginComponent},
  //{path:'prueba',component:NavComponent,canActivate:[GuardfirstGuard]},
  //{path:'detalles',component:DetallesComponent,canActivate:[GuardfirstGuard]},
  // {path:'detalles',component:DetallesComponent},
  {path:'principal',component:PrincipalComponent},
  //{path:'header',component:HeaderComponent},
  {path:'equipo', component:EquipoComponent},
  // {path:'trailers', component:CrudTrailersComponent},
  {path:'**',redirectTo:'principal', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
