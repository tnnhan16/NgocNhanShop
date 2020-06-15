import { DatePipe } from "@angular/common";

export interface IUser {
    id: any;
    userName: string;
    password: string;
    confirmPassword:string;
    firstName: string;
    lastName: string;
    email:string;
    birthDay:Date;
    phoneNumber:string;
    userCreate:any;
    userUpdate:any;
}

export class User implements IUser {
    id: any;
    userName: string;
    password: string;
    confirmPassword:string;
    firstName: string;
    lastName: string;
    email:string;
    birthDay:Date;
    phoneNumber:string;
    userCreate:any;
    userUpdate:any;
    constructor(data: IUser){
        this.id = data.id;
        this.userName = data.userName;
        this.firstName = data.firstName;
        this.lastName = data.lastName;
        this.email = data.email;
        this.birthDay = data.birthDay;
        this.phoneNumber = data.phoneNumber;
        this.userCreate = data.userCreate;
        this.userUpdate = data.userUpdate;
    }
}