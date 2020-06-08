import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { UserComponent } from './user.component';
import { AddUserComponent } from './add/add-user.component';
import { EditUserComponent } from './edit/edit-user.component';
import { DetailUserComponent } from './detail/detail-user.component';
import { DeleteUserComponent } from './delete/delete-user.component';

const routes: Routes = [
     
    { path: '', component: UserComponent },
    { path: 'add', component: AddUserComponent },
    { path: 'edit/:id', component: EditUserComponent },
    { path: 'detail/:id', component: DetailUserComponent },
    { path: 'delete/:id', component: DeleteUserComponent },
];

@NgModule({
    imports:[
        RouterModule.forChild(routes),
    ],
    exports: [RouterModule]
})
export class UserRoutingModule {

}