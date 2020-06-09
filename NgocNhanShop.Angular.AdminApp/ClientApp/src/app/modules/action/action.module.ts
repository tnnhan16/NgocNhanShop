import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActionRoutingModule } from './action.routing';
import { ActionComponent } from './action.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwPaginationModule } from 'src/app/shared/components/jw-pagination/jw-pagination.module';

@NgModule({
  declarations: [
    ActionComponent,
  ],
  imports: [
    CommonModule,
    ActionRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    JwPaginationModule,
  ]
})
export class ActionModule { }
