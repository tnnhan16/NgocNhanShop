import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DashboardComponent } from 'src/app/components/dashboard/dashboard.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgbModule,
  ],
  declarations: [
    DashboardComponent
  ]
})

export class AdminLayoutModule {}
