import { Component, OnInit } from '@angular/core';
import { ActionService } from 'src/app/services/action.service';
import { Action } from 'src/app/models/action';

@Component({
  selector: 'app-action',
  templateUrl: './action.component.html',
  styleUrls: ['./action.component.css']
})
export class ActionComponent implements OnInit {
  items: Action[];
 pageOfItems: Array<Action>;
  constructor(private actionService: ActionService) { }

  ngOnInit() {
    this.actionService.getAll()
    .subscribe(
      result => {
        this.items = result.resultObj.items;
      },
      error => console.error(error)
      );
  }
  onChangePage(pageOfItems: Array<any>) {
    this.pageOfItems = pageOfItems;
  }

}
