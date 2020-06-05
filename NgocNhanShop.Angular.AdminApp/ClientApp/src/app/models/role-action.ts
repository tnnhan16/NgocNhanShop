import { DatePipe } from "@angular/common";
import { Role } from "./role";
import { Action } from "./action";

export interface IRoleAction {
    id: string;
    roleId: string;
    actionId: string;
    role:Role;
    action:Action;
    
}

export class RoleAction implements IRoleAction {
    id: string;
    roleId: string;
    actionId: string;
    role:Role;
    action:Action;
    constructor(data: IRoleAction){
        this.id = data.id;
        this.roleId = data.roleId;
        this.actionId = data.actionId;
        this.role = data.role;
        this.action = data.action;

    }
}