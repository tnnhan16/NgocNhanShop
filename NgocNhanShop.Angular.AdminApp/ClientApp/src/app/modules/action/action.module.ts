import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActionRoutingModule } from './action.routing';
import { ActionComponent } from './action.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ActionComponent,
  ],
  imports: [
    CommonModule,
    ActionRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class ActionModule { }
