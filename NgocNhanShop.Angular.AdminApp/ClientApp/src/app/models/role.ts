import { DatePipe } from "@angular/common";
import { Action } from "./action";

export interface IRole {
    id: string;
    name: string;
    description: string;
    actions:Action[];
}

export class Role implements IRole {
    id: string;
    name: string;
    description: string;
    actions:Action[];
    constructor(data: IRole){
        this.id = data.id;
        this.name = data.name;
        this.description = data.description;
        this.actions = data.actions;
    }
}