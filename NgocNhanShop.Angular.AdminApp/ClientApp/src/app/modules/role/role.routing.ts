import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AdminLayoutComponent } from 'src/app/shared/modules/layouts/admin-layout/admin-layout.component';
import { AuthGuard } from 'src/app/shared/helpers/auth.guard';
import { RoleComponent } from './role.component';
import { AddRoleComponent } from './add/add-role.component';


const routes: Routes = [
     
    { path: '', component: RoleComponent },
    { path: 'add', component: AddRoleComponent },
];

@NgModule({
    imports:[
        RouterModule.forChild(routes),
    ],
    exports: [RouterModule]
})
export class RoleRoutingModule {

}