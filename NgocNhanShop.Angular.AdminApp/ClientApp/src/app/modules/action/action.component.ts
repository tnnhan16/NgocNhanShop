import { Component, OnInit } from '@angular/core';
import { ActionService } from 'src/app/services/action.service';
import { Action } from 'src/app/models/action';
import { RequestBase } from 'src/app/models/request-base';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-action',
  templateUrl: './action.component.html',
  styleUrls: ['./action.component.css']
})
export class ActionComponent implements OnInit {
  items: Action[];
  total:number;
  pageOfItems: Array<Action>;
  pageIndex:number;
  pageSize:number;
  maxPages:number = 1;
  constructor(private actionService: ActionService) { }

  ngOnInit() {
    let request= new RequestBase();
    request.keyword = '';
    this.actionService.getAll(request)
    .subscribe(
      result => {
        this.items = result.resultObj.items;
        this.total = result.resultObj.total;
        this.pageSize = result.resultObj.pageSize;
        this.maxPages = result.resultObj.pageCount;
      },
      error => console.error(error)
      );
  }
  onChangePage(page:number) {
    let request= new RequestBase();
    request.keyword = '';
    request.pageIndex = page;
    this.actionService.getAll(request).pipe(take(1))
    .subscribe(
      result => {
        this.items = result.resultObj.items;
        this.total = result.resultObj.total;
        this.pageIndex = result.resultObj.pageIndex;
        this.pageSize = result.resultObj.pageSize;
        this.maxPages = result.resultObj.pageCount;
      },
      error => console.error(error)
      );
  }

}
