import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AlertComponent } from './shared/components/alert/alert.component';
import { JwtInterceptor } from './shared/helpers/jwt.interceptor';
import { ErrorInterceptor } from './shared/helpers/error.interceptor';
// import { fakeBackendProvider } from './shared/helpers/fake-backend';
import { AppRoutingModule } from './app.routing';
import { SidebarModule } from './shared/modules/layouts/sidebar/sidebar.module';
import { NavbarModule } from './shared/modules/layouts/navbar/navbar.module';
import { FooterModule } from './shared/modules/layouts/footer/footer.module';
import { AdminLayoutComponent } from './shared/modules/layouts/admin-layout/admin-layout.component';
import { AdminLayoutModule } from './shared/modules/layouts/admin-layout/admin-layout.module';
import { LoginFormComponent } from './modules/user/login/login-form.component';
import { RegisterUserFormComponent } from './modules/user/register/register-user-form.component';
import { UserComponent } from './modules/user/user.component';
import { UserModule } from './modules/user/user.module';
import { DatePipe } from '@angular/common';
import { AddUserComponent } from './modules/add/add-user.component';

@NgModule({
  declarations: [
    AppComponent,
    FetchDataComponent,
    LoginFormComponent,
    RegisterUserFormComponent,
    AlertComponent,
    AdminLayoutComponent,
    UserComponent,
    AddUserComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SidebarModule,
    NavbarModule,
    FooterModule,
    AdminLayoutModule,
    UserModule,
  ],
  providers: [
    DatePipe,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    // provider used to create fake backend
    // fakeBackendProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
