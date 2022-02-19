import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientiRoutingModule } from './clienti-routing.module';
import { ClientiComponent } from './clienti/clienti.component';
import { ChildComponent } from './child/child.component';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { ClientComponent } from './client/client.component';
import { MatCardModule } from '@angular/material/card';
import { MarksPipe } from 'src/app/marks.pipe';
import { HoverBtnDirective } from 'src/app/hover-btn.directive';
import { MyDirectiveDirective } from 'src/app/my-directive.directive';

@NgModule({
  declarations: [
    ClientiComponent,
    ChildComponent,
    ClientComponent,
    MarksPipe,
    HoverBtnDirective,
    MyDirectiveDirective,
  ],
  imports: [
    CommonModule,
    ClientiRoutingModule,
    MatTableModule,
    MatIconModule,
    MatCardModule,
  ],
  exports: [
    MarksPipe,
    HoverBtnDirective,
    MyDirectiveDirective,
  ]
})
export class ClientiModule { }
