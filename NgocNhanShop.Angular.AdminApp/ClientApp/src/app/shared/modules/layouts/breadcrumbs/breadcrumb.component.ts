import { Component, OnInit } from '@angular/core';
import { Location} from '@angular/common';
import  *  as  breadcrumbs  from  './breadcrumb.json';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
    selector: 'app-breadcrumb',
    templateUrl: 'breadcrumb.component.html',
    styleUrls: ['./breadcrumb.component.css']
})

export class BreadcrumbComponent implements OnInit{

    listBreadcrumbs:RouterClass[] = [];
    constructor(private location:Location,private router: Router) {
      this.router.events
      .pipe(
        filter(events => events instanceof NavigationEnd)
      )
      .subscribe(x => {
        this.renderBreadcrumb();
      });
    }

    ngOnInit(){
      
    }
    renderBreadcrumb(){
      this.listBreadcrumbs= [];
      let routerPath = ""
      let urlPath = this.router.url;
      let url = urlPath.split("/");
      url.forEach(element => {  
        if(element != ""){
          routerPath =  routerPath + "/" + element;  
          if(breadcrumbs['default'][routerPath]){
            let routerClass = new RouterClass();
            routerClass.path =   routerPath;
            routerClass.lable =  breadcrumbs['default'][routerPath]['lable'];
            this.listBreadcrumbs.push(routerClass);
          }
        }
      })
    }
}
class RouterClass
{ 
  path:string;
  lable:string;
};
