import { Component, OnInit } from '@angular/core';


export interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}

export const ROUTES: RouteInfo[] = [
    { path: '/icons',           title: 'Icons',             icon:'nc-diamond',    class: '' },
    { path: '/maps',            title: 'Maps',              icon:'nc-pin-3',      class: '' },
    { path: '/notifications',   title: 'Notifications',     icon:'nc-bell-55',    class: '' },
    { path: '/admin/users',     title: 'Người dùng',        icon:'nc-single-02',  class: '' },
    { path: '/admin/role',      title: 'Roles',             icon:'nc-settings-gear-65',    class: '' },
    { path: '/admin/action',    title: 'Settings',        icon:'nc-icon nc-settings', class: '' },
];

@Component({
    selector: 'sidebar-cmp',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent implements OnInit {
    public menuItems: any[];
    selected;
    ngOnInit() {
        this.menuItems = ROUTES;
    }
    select(item:any){
        this.selected = item; 
    }
    isActive(item:any){
        return this.selected === item;
    }
}
