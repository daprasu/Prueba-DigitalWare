import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginFormComponent, ResetPasswordFormComponent, CreateAccountFormComponent, ChangePasswordFormComponent } from './shared/components';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { ClienteComponent } from './pages/cliente/cliente.component';
import { DxButtonModule, DxDataGridModule, DxFormModule, DxPopupModule, DxScrollViewModule, DxTemplateModule } from 'devextreme-angular';
import { VentaComponent } from './pages/venta/venta.component';
import { ProductoComponent } from './pages/producto/producto.component';

const routes: Routes = [
  {
    path: 'cliente',
    component: ClienteComponent
  },
  {
    path: 'venta',
    component: VentaComponent,
  },
  {
    path: 'producto',
    component: ProductoComponent
  },

  {
    path: 'profile',
    component: ProfileComponent
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'login-form',
    component: LoginFormComponent
  },
  {
    path: 'reset-password',
    component: ResetPasswordFormComponent
  },
  {
    path: 'create-account',
    component: CreateAccountFormComponent
  },
  {
    path: 'change-password/:recoveryCode',
    component: ChangePasswordFormComponent
  },
  {
    path: '**',
    redirectTo: 'home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true }), DxDataGridModule, DxFormModule,
    DxPopupModule,
    DxScrollViewModule,
    DxTemplateModule,DxButtonModule,
    DxTemplateModule],
  exports: [RouterModule],
  declarations: [
    HomeComponent,
    ProfileComponent,
    ClienteComponent,
    VentaComponent,
    ProductoComponent
  ]
})
export class AppRoutingModule { }
