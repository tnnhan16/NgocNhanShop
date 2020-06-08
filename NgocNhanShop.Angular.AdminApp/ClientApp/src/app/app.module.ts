import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { AlertComponent } from './shared/components/alert/alert.component';
import { JwtInterceptor } from './shared/helpers/jwt.interceptor';
import { ErrorInterceptor } from './shared/helpers/error.interceptor';
import { AppRoutingModule } from './app.routing';
import { SidebarModule } from './shared/modules/layouts/sidebar/sidebar.module';
import { NavbarModule } from './shared/modules/layouts/navbar/navbar.module';
import { FooterModule } from './shared/modules/layouts/footer/footer.module';
import { AdminLayoutComponent } from './shared/modules/layouts/admin-layout/admin-layout.component';
import { AdminLayoutModule } from './shared/modules/layouts/admin-layout/admin-layout.module';
import { LoginFormComponent } from './modules/user/system/login/login-form.component';
import { RegisterUserFormComponent } from './modules/user/system/register/register-user-form.component';
import { UserModule } from './modules/user/user.module';
import { DatePipe } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RoleModule } from './modules/role/role.module';
import { ActionModule } from './modules/action/action.module';

@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    RegisterUserFormComponent,
    AlertComponent,
    AdminLayoutComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,

    //module playout app
    SidebarModule,
    NavbarModule,
    FooterModule,
    AdminLayoutModule,

    //module app
    UserModule,
    ActionModule,
    RoleModule,
    BrowserAnimationsModule,

    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-top-right',
      preventDuplicates: false,
      disableTimeOut: false
    }),
    
  ],
  providers: [
    DatePipe,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],

})
export class AppModule { }
