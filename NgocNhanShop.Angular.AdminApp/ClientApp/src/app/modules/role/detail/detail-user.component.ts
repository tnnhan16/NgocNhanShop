import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { finalize } from 'rxjs/operators';
import { User } from 'src/app/models/user';
import { ToastrService } from 'ngx-toastr';

@Component({ templateUrl: 'detail-user.component.html' })
export class DetailUserComponent implements OnInit {
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
}
