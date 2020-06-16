import { ActionNameOption } from "./action-name-option";

export interface IControllerNameOption {
    
  controllerName: string;
  actionNameOptions:ActionNameOption[];
}

export class ControllerNameOption {

    controllerName: string;
    actionNameOptions:ActionNameOption[];

    constructor(data:IControllerNameOption){
      this.controllerName = data.controllerName;
      this.actionNameOptions = data.actionNameOptions;
    }
}
