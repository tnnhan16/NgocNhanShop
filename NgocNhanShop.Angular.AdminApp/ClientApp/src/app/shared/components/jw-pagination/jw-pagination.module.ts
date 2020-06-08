import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JwPaginationComponent } from 'src/app/shared/components/jw-pagination/jw-pagination.component';

@NgModule({
  declarations:[JwPaginationComponent],
  imports: [CommonModule],
  exports:[JwPaginationComponent]
})
export class JwPaginationModule { }
