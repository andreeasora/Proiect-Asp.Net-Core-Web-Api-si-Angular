import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdaugaUpdateazaComponent } from './adauga-updateaza/adauga-updateaza.component';
import { MaterialModule } from '../material/material.module';
import { MatDialogModule } from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AdaugaUpdateazaComponent,
   
  ],
  imports: [
    CommonModule,
    MaterialModule,
    MatDialogModule,
    ReactiveFormsModule,
    
  ],
  entryComponents: [
    AdaugaUpdateazaComponent
  ]
})
export class ModalModule { }
