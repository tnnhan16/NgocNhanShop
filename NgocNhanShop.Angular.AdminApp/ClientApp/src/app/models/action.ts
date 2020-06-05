import { DatePipe } from "@angular/common";
import { Role } from "./role";

export interface IAction {
    id: string;
    actionName: string;
    description: string;
    roles:Role[];
    
}

export class Action implements IAction {
    id: string;
    actionName: string;
    description: string;
    roles:Role[];
    constructor(data: IAction){
        this.id = data.id;
        this.actionName = data.actionName;
        this.description = data.description;
        this.roles = data.roles;
    }
}