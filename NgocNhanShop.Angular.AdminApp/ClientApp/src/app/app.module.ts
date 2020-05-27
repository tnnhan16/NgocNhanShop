import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginFormComponent } from './user/login-form/login-form.component';
import { RegisterUserFormComponent } from './user/register-user-form/register-user-form.component';
import { AlertComponent } from './alert/alert.component';
import { JwtInterceptor } from './shared/helpers/jwt.interceptor';
import { ErrorInterceptor } from './shared/helpers/error.interceptor';
import { fakeBackendProvider } from './shared/helpers/fake-backend';
import { AppRoutingModule } from './app.routing';

@NgModule({
  declarations: [
    AppComponent,
    
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginFormComponent,
    RegisterUserFormComponent,
    AlertComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    // provider used to create fake backend
    fakeBackendProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
