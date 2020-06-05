import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ConfirmedValidator } from 'src/app/shared/helpers/confirmed.validator';
import { ResponseApi } from 'src/app/models/response-api';
import { MessageError } from 'src/app/models/message-error';
import { HttpErrorResponse } from '@angular/common/http';
import { finalize } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { RoleService } from 'src/app/services/role.service';

@Component({ 
  templateUrl: 'add-role.component.html',
  styleUrls: ['./add-role.component.css']
})
export class AddRoleComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;
  messageError: MessageError = {};

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private roleService: RoleService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      name: new FormControl('',[Validators.required]),
      description: new FormControl('', [Validators.required]),
    });
  }
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }
    this.loading = true;
    this.roleService.register(this.registerForm.value)
      .pipe
      (finalize(() => {
        this.loading = false;
      }))
      .subscribe(
        data => {
          this.router.navigate(['/admin/role']);
          this.toastr.success('Đăng ký role thành công!', 'Thông báo');
        },
        error=> {
          if (error instanceof HttpErrorResponse) {
            let result:ResponseApi<boolean> = error.error;
            result.listError.forEach(element => {
              if(element.key != null && element.value != null){
                var key = element.key;
                this.messageError[key] = element.value;
              }
            });
          }
          this.toastr.warning('Thông tin nhập chưa hợp lệ!', 'Thông báo');
        }
      );
  }
}
