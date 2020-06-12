import { Component, OnInit } from '@angular/core';
import { Role } from 'src/app/models/role';
import { RoleService } from 'src/app/services/role.service';
import { RequestBase } from 'src/app/models/request-base';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css']
})
export class RoleComponent implements OnInit {
  items: Role[];
  total:number;
  pageIndex:number;
  pageSize:number;
  pageCount:number = 1;
  constructor(private userService: RoleService) { }

  ngOnInit() {
    let request = new RequestBase();
    this.getPagingAll(request)
  }

  onChangePage(page: number) {
    let request = new RequestBase();
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
