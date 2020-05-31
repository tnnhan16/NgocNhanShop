import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { AlertService } from 'src/app/shared/services/alert.service';
import { ConfirmedValidator } from 'src/app/shared/helpers/confirmed.validator';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/user';
import { ResponseError } from 'src/app/models/response-error';
import { ResponseApi } from 'src/app/models/response-api';
import { MessageError } from 'src/app/models/message-error';

@Component({ templateUrl: 'add-user.component.html' })
export class AddUserComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;
  messageError: MessageError = {};

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authenticationService: AuthenticationService,
    private userService: UserService,
    private alertService: AlertService
  ) {}

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      firstName: new FormControl('',[Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      birthday:new FormControl('',[Validators.required, Validators.pattern(/^\d{4}(\-)(((0)[0-9])|((1)[0-2]))(\-)([0-2][0-9]|(3)[0-1])$/)]),
      username: new FormControl('', [Validators.required]),
      phoneNumber: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(15), Validators.pattern("^[0-9]*$")]),
      password: new FormControl('',[Validators.required, Validators.minLength(6)]),
      confirmPassword: new FormControl('',[Validators.required, Validators.minLength(6)]),
      email: new FormControl('',[Validators.required,Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]),
    },
    { 
      validator: ConfirmedValidator('password', 'confirmPassword')
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;

    // reset alerts on submit
    this.alertService.clear();

    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }

    this.loading = true;
    this.userService.register(this.registerForm.value)
      .subscribe(
        data => {
          if(data.isSuccessed){
            this.alertService.success('Registration successful', true);
            this.router.navigate(['/admin/users']);
          } else {
            if(data.listError != null){
              data.listError.forEach(element => {
                if(element.key != null && element.value != null){
                  let key = element.key;
                  this.messageError.key = element.value;
                }
              });
            }
          }
        },
        error => {
          this.alertService.error(error);
          this.loading = false;
          error;
        });
  }
}
