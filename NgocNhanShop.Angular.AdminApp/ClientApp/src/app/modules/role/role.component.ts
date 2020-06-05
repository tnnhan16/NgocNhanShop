import { Component, OnInit } from '@angular/core';
import { Role } from 'src/app/models/role';
import { RoleService } from 'src/app/services/role.service';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css']
})
export class RoleComponent implements OnInit {
  items: Role[];
 pageOfItems: Array<Role>;
  constructor(private userService: RoleService) { }

  ngOnInit() {
    this.userService.getAll()
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
