import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { AlertService } from 'src/app/shared/services/alert.service';
import { UserService } from 'src/app/services/user.service';
import { ResponseApi } from 'src/app/models/response-api';
import { MessageError } from 'src/app/models/message-error';
import { HttpErrorResponse } from '@angular/common/http';
import { finalize } from 'rxjs/operators';
import { User } from 'src/app/models/user';

@Component({ templateUrl: 'edit-user.component.html' })
export class EditUserComponent implements OnInit {
  form: FormGroup;
  loading = false;
  submitted = false;
  messageError: MessageError = {};
  user:User;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private userService: UserService,
    private alertService: AlertService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit() {
    let idUser = this.route.snapshot.params['id'];
    this.getById(idUser);
  }

  // convenience getter for easy access to form fields
  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;
    // reset alerts on submit
    this.alertService.clear();
    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }
    this.loading = true;
    this.userService.register(this.form.value)
      .pipe
      (finalize(() => {
        this.loading = false;
      }))
      .subscribe(
        data => {
          this.alertService.success('Registration successful', true);
          this.router.navigate(['/admin/users']);
        },
        error => {
          if (error instanceof HttpErrorResponse) {
            let result: ResponseApi<boolean> = error.error;
            result.listError.forEach(element => {
              if (element.key != null && element.value != null) {
                var key = element.key;
                this.messageError[key] = element.value;
              }
            });
          }
        }
      );
  }
  getById(idUser:any){
    this.loading = true;
    this.userService.getById(idUser)
      .pipe
      (finalize(() => {
        this.loading = false;
      }))
      .subscribe(
        data => {
          this.user = data.resultObj;
          console.log(data.resultObj);
          this.validatorForm();
        },
        error => {
          console.log(error)
          // this.router.navigate(['/admin/users']);
        });
  }
  validatorForm(){
    this.form = this.formBuilder.group({
      firstName: new FormControl(this.user.firstName, [Validators.required]),
      lastName: new FormControl(this.user.lastName, [Validators.required]),
      birthDay: new FormControl(this.user.birthDay, [Validators.required, Validators.pattern(/^\d{4}(\-)(((0)[0-9])|((1)[0-2]))(\-)([0-2][0-9]|(3)[0-1])$/)]),
      phoneNumber: new FormControl(this.user.phoneNumber, [Validators.required, Validators.minLength(5), Validators.maxLength(15), Validators.pattern("^[0-9]*$")]),
      email: new FormControl(this.user.email, [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]),
    }); 
  }
}
