import { Component, OnInit } from '@angular/core';
import { ActionService } from 'src/app/services/action.service';
import { Action } from 'src/app/models/action';
import { RequestBase } from 'src/app/models/request-base';
import { UserInfo } from 'src/app/models/user-info';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { ToastrService } from 'ngx-toastr';
import { RequestData } from 'src/app/models/request-data';
import { RequestActionUpdate } from 'src/app/models/action/request-action-update';
import { Router } from '@angular/router';

@Component({
  selector: 'app-action',
  templateUrl: './action.component.html',
  styleUrls: ['./action.component.css']
})

export class ActionComponent implements OnInit {
  items: Action[]
  total:number
  pageIndex:number
  pageSize:number
  pageCount:number = 1
  currentUser:UserInfo
  idActionSelected: string

  constructor(
    private actionService: ActionService,  
    private authenticationService: AuthenticationService,
    private toastr: ToastrService,
    private router: Router) { }

  ngOnInit() {
    let request = new RequestBase();
    this.getPagingAll(request);
    this.currentUser = this.authenticationService.currentUserValue;
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
  ShowOrHiden(item:Action){
    this.idActionSelected = item.id;
  }

  onEdit(item:Action, description:string){
    if (this.currentUser) {
      let action = new RequestActionUpdate();
      action.userUpdate = this.currentUser.user.id;
      action.description = description;
      return this.actionService.edit(item.id, action)
      .subscribe(
        result => {
          this.idActionSelected = ''
          item.description = description
          this.toastr.success('Cập nhật quyền hệ thống thành công!', 'Thông báo')
          this.router.navigate(['/admin/action']);
        },
        error => {
          this.toastr.error('Cập nhật quyền hệ thống thất bại!', 'Thông báo')
          console.error(error)
        });
    }

  }
  RenderAcrion(){
    let requestData = new RequestData();
    requestData.userCreate = this.currentUser.user.id;
    return this.actionService.render(requestData)
    .subscribe(
      result => {
        this.toastr.success('Cập nhật quyền hệ thống thành công!', 'Thông báo')
        return result.isSuccessed;
      },
        error => {
          this.toastr.error('Cập nhật quyền hệ thống thất bại!', 'Thông báo')
          console.error(error)
        }
      );
  }

}
