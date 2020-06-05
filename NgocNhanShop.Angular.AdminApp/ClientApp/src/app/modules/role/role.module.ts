import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTreeModule } from '@angular/material/tree';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { TreeCheckboxesComponent } from 'src/app/shared/components/tree-checkboxes/tree-checkboxes.component';
import { RoleRoutingModule } from './role.routing';
import { RoleComponent } from './role.component';
import { AddRoleComponent } from './add/add-role.component';
import { JwPaginationComponent } from 'src/app/shared/components/jw-pagination/jw-pagination.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    TreeCheckboxesComponent,
    RoleComponent,
    AddRoleComponent,
    JwPaginationComponent,
  ],
  imports: [
    CommonModule,
    RoleRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatTreeModule,
    MatCheckboxModule,
    MatInputModule,
    MatIconModule,

  ], exports: [
    JwPaginationComponent
  ]
})
export class RoleModule { }
