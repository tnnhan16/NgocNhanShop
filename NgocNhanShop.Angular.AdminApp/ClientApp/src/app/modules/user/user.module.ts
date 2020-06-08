import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// import { JwPaginationComponent } from 'src/app/shared/components/jw-pagination/jw-pagination.component';
import { UserComponent } from './user.component';
import { AddUserComponent } from './add/add-user.component';
import { EditUserComponent } from './edit/edit-user.component';
import { DetailUserComponent } from './detail/detail-user.component';
import { DeleteUserComponent } from './delete/delete-user.component';
import { UserRoutingModule } from './user.routing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwPaginationModule } from 'src/app/shared/components/jw-pagination/jw-pagination.module';

@NgModule({
  declarations: [
    UserComponent,
    AddUserComponent,
    EditUserComponent,
    DetailUserComponent,
    DeleteUserComponent,
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    JwPaginationModule,
  ]
})
export class UserModule { }
