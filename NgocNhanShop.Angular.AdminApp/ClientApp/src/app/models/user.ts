import { DatePipe } from "@angular/common";

export interface IUser {
    id: string;
    userName: string;
    password: string;
    confirmPassword:string;
    firstName: string;
    lastName: string;
    email:string;
    birthDay:Date;
    phoneNumber:string;
}

export class User implements IUser {
    id: string;
    userName: string;
    password: string;
    confirmPassword:string;
    firstName: string;
    lastName: string;
    email:string;
    birthDay:Date;
    phoneNumber:string;
    constructor(data: IUser){
        this.id = data.id;
        this.userName = data.userName;
        this.firstName = data.firstName;
        this.lastName = data.lastName;
        this.email = data.email;
        this.birthDay = data.birthDay;
        this.phoneNumber = data.phoneNumber;

    }
}