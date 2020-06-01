import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
 listUser: User[];
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getAll()
    .subscribe(
      result => {
        this.listUser = result.resultObj.items;
      },
      error => console.error(error)
      );
  }

}
