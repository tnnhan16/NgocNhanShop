import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './shared/helpers/auth.guard';
import { NgModule } from '@angular/core';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AdminLayoutComponent } from './shared/modules/layouts/admin-layout/admin-layout.component';
import { LoginFormComponent } from './modules/user/system/login/login-form.component';
import { RegisterUserFormComponent } from './modules/user/system/register/register-user-form.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UserComponent } from './modules/user/user.component';
import { AddUserComponent } from './modules/user/add/add-user.component';
import { EditUserComponent } from './modules/user/edit/edit-user.component';

const routes: Routes = [
    { path: 'admin', component: AdminLayoutComponent, canActivate: [AuthGuard],
    children:[
        { path: '', component: DashboardComponent},
        { path: 'users', component: UserComponent,       
            children:[            
                // { path: 'add', component: AddUserComponent},
                // { path: 'detail/:id', component: AddUserComponent},
                // { path: 'delete/:id', component: AddUserComponent}
            ]
        },
        { path: 'users/add', component: AddUserComponent},
        { path: 'users/edit/:id', component:EditUserComponent},

    ]

    },
    { path: 'login', component: LoginFormComponent },
    { path: 'register', component: RegisterUserFormComponent },
    { path: 'fetch-data', component: FetchDataComponent },
    

    // otherwise redirect to home
    { path: '**', redirectTo: 'admin' }
];

@NgModule({
    imports:[
        RouterModule.forRoot(routes),
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {

}