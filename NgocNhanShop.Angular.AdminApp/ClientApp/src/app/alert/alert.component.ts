import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs'
import { AlertService } from '../shared/services/alert.service';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css']
})
export class AlertComponent implements OnInit {
  private subscription : Subscription;
  public message : any;
  constructor(private alertService: AlertService) { }

  ngOnInit() {
    this.subscription = this.alertService.getAlert()
    .subscribe(message => {
      switch (message && message.type) {
        case 'success':
            message.cssClass = 'alert alert-success';
            break;
        case 'error':
            message.cssClass = 'alert alert-danger';
            break;
    }

    this.message = message;
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
}

}
