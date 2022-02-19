import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientComponent } from './client/client.component';
import { ClientiComponent } from './clienti/clienti.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'clienti',
  },
  {
    path: 'clienti',
    component: ClientiComponent,
  },
  {
    path: 'client/:id',
    component: ClientComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientiRoutingModule { }
