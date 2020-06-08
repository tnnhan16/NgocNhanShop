import { DatePipe } from "@angular/common";
import { Role } from "./role";

export interface IAction {
    id: string;
    controllerName: string;
    actionName: string;
    description: string;
    userCreate: string;
    userUpdate:string;
    createTime:Date;
    updateTime:Date;
    roles:Role[];
    
}

export class Action implements IAction {
    id: string;
    controllerName: string;
    actionName: string;
    description: string;
    userCreate: string;
    userUpdate:string;
    createTime:Date;
    updateTime:Date;
    roles:Role[];
    constructor(data: IAction){
        this.controllerName = data.controllerName;
        this.id = data.id;
        this.actionName = data.actionName;
        this.description = data.description;
        this.userCreate = data.userCreate;
        this.userUpdate = data.userUpdate;
        this.createTime = data.createTime;
        this.updateTime = data.updateTime;
        this.roles = data.roles;
    }
}