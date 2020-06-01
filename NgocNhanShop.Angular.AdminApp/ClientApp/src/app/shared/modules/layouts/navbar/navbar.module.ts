import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './navbar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BreadcrumbComponent } from '../breadcrumbs/breadcrumb.component';

@NgModule({
    imports: [ RouterModule, CommonModule, NgbModule ],
    declarations: [ NavbarComponent, BreadcrumbComponent],
    exports: [ NavbarComponent ]
})

export class NavbarModule {}
