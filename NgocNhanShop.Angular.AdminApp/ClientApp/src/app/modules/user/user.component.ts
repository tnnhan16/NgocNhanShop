import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';
import { RequestBase } from 'src/app/models/request-base';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  items: User[];
  total:number;
  pageIndex:number;
  pageSize:number;
  pageCount:number = 1;
  constructor(private userService: UserService) { }

  ngOnInit() {
    let request = new RequestBase()
    this.getPagingAll(request)
  }

  onChangePage(page: number) {
    let request = new RequestBase()
    request.pageIndex = page
    this.getPagingAll(request)
  }

  getPagingAll(request : RequestBase){
    return this.userService.getAll(request)
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

}
