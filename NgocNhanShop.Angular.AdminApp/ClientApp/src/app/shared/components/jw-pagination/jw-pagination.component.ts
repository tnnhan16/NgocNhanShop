import { Component, Input, Output, EventEmitter, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import paginate from 'jw-paginate';

@Component({
  selector: 'jw-pagination',
  templateUrl: './jw-pagination.component.html',
  styleUrls: ['./jw-pagination.component.css']
})
export class JwPaginationComponent implements OnInit, OnChanges {
  @Output() changePage = new EventEmitter<number>();
  @Input() pageSize = 10;
  @Input() pageCount = 1;
  @Input() total = 0;
  @Input() pageIndex = 1;
  pager: any = {};

  ngOnInit() {}

  ngOnChanges(changes: SimpleChanges) {
    this.setPage(this.pageIndex);
  }

  setPage(page: number) {
    // get new pager object for specified page
    this.pager = paginate(this.total, page, this.pageSize, this.pageCount);
    // call change page function in parent component
    this.changePage.emit(page);
  }
}
