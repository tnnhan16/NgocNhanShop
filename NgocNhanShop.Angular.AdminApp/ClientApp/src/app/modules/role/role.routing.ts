import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
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