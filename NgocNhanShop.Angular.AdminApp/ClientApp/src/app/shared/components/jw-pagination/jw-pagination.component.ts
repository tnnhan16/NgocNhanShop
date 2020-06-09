import { Component, Input, Output, EventEmitter, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import paginate from 'jw-paginate';

@Component({
  selector: 'jw-pagination',
  templateUrl: './jw-pagination.component.html',
  styleUrls: ['./jw-pagination.component.css']
})
export class JwPaginationComponent implements OnInit, OnChanges {
  @Output() changePage = new EventEmitter<number>();
  @Input() initialPage = 1;
  @Input() pageSize = 10;
  @Input() maxPages = 1;
  @Input() total = 0;
  @Input() pageIndex = 1;
  pager: any = {};

  ngOnInit() {
    // set page if items array isn't empty
      this.setPage(this.initialPage);
  }

  ngOnChanges(changes: SimpleChanges) {
    this.setPage(this.pageIndex);
  }

  setPage(page: number) {

    // get new pager object for specified page
    this.pager = paginate(this.total, page, this.pageSize, this.maxPages);
    console.log(this.maxPages)
    // call change page function in parent component
    this.changePage.emit(page);
    this.pageIndex = page;
  }
}
