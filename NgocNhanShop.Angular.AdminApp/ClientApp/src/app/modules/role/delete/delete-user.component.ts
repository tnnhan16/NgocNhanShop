import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { finalize } from 'rxjs/operators';
import { User } from 'src/app/models/user';
import { ToastrService } from 'ngx-toastr';

@Component({ templateUrl: 'delete-user.component.html' })
export class DeleteUserComponent implements OnInit {
  loading = false;
  user:User;
  idUser:string;

  constructor(
    private router: Router,
    private userService: UserService,
    private route: ActivatedRoute,
    private toastr: ToastrService,
  ) { }

  ngOnInit() {
    this.idUser = this.route.snapshot.params['id'];
    this.getById(this.idUser);
  }
  getById(idUser:any){
    this.loading = true;
    this.userService.getDetail(idUser)
      .pipe
      (finalize(() => {
        this.loading = false;
      }))
      .subscribe(
        data => {
          this.user = data.resultObj;
        },
        error => {
          this.router.navigate(['/admin/users']);
          this.toastr.warning('Người dùng không tìm thấy!', 'Thông báo');
        });
  }

  deleteUser() {
    if(this.idUser == null || this.idUser == ""){
      this.router.navigate(['/admin/users']);
      this.toastr.error('Xóa người dùng thất bại!', 'Thông báo');
    }
    this.loading = true;
    this.userService.delete(this.idUser)
      .pipe
      (finalize(() => {
        this.loading = false;
      }))
      .subscribe(
        data => {
          this.router.navigate(['/admin/users']);
          this.toastr.success('Xóa người dùng thành công!', 'Thông báo');
        },
        error => {
          this.router.navigate(['/admin/users']);
          this.toastr.error('Xóa người dùng thất bại!', 'Thông báo');
        }
      );
  }
}
