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
  pageIndex:number;
  pageSize:number;
  pageCount:number = 1;


  constructor(private actionService: ActionService) { }

  ngOnInit() {
    let request = new RequestBase();
    this.getPagingAll(request);
  }

  onChangePage(page:number) {
    let request = new RequestBase();
    request.pageIndex = page;
    this.getPagingAll(request);
  }

  getPagingAll(request: RequestBase){
    return this.actionService.getAll(request)
    .subscribe(
      result => {
        this.items = result.resultObj.items;
        this.total = result.resultObj.total;
        this.pageSize = result.resultObj.pageSize;
        this.pageCount = result.resultObj.pageCount;
      },
      error => console.error(error)
      );
  }

  onEdit(id:string, description:string){
    alert(description)

  }

}
