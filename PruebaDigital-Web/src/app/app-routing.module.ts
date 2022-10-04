import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginFormComponent, ResetPasswordFormComponent, CreateAccountFormComponent, ChangePasswordFormComponent } from './shared/components';
import { AuthGuardService } from './shared/services';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { ClienteComponent } from './pages/cliente/cliente.component';
import { DxDataGridModule, DxFormModule } from 'devextreme-angular';
import { VentaComponent } from './pages/venta/venta.component';
import { ProductoComponent } from './pages/producto/producto.component';
import { VentaDetalleComponent } from './pages/venta-detalle/venta-detalle.component';

const routes: Routes = [
  {
    path: 'cliente',
    component: ClienteComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'venta',
    component: VentaComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'producto',
    component: ProductoComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'venta-detalle',
    component: VentaDetalleComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'login-form',
    component: LoginFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'reset-password',
    component: ResetPasswordFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'create-account',
    component: CreateAccountFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'change-password/:recoveryCode',
    component: ChangePasswordFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: '**',
    redirectTo: 'home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true }), DxDataGridModule, DxFormModule],
  providers: [AuthGuardService],
  exports: [RouterModule],
  declarations: [
    HomeComponent,
    ProfileComponent,
    ClienteComponent,
    VentaComponent,
    ProductoComponent,
    VentaDetalleComponent
  ]
})
export class AppRoutingModule { }
