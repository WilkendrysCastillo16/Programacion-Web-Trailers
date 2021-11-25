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
  {path:'detalles',component:DetallesComponent},
  {path:'**',redirectTo:'login'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
