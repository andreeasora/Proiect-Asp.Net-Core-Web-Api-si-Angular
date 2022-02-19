import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { RegisterComponent } from './modules/auth/register/register.component';

const routes: Routes = [
  { path:"", redirectTo:'/register', pathMatch: 'full'},
  {
    path: '',
    canActivate: [AuthGuard],
    children:[
      {
        path:'',
        loadChildren: () => import('src/app/modules/clienti/clienti.module').then(m=>m.ClientiModule),
      },
    ]
  },
  {
    path:'',
    loadChildren: () => import('src/app/modules/clienti/clienti.module').then(m=>m.ClientiModule),
  },
  {
    path:'register',
    component: RegisterComponent
  },
  {
    path: 'login',
    loadChildren: () => import('src/app/modules/auth/auth.module').then(m => m.AuthModule),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
