import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { map } from 'rxjs/operators';
import { ResponseApi } from '../models/response-api';


@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<ResponseApi<User[]>>(environment.ApiUrlBase + '/api/users/paging').pipe(
            map(res=>{
                const users: User[] = [];
                res.resultObj.items.forEach(item => {
                    users.push(new User(item));
                });
                res.resultObj.items = users
                return res
            })
        );
    }

    register(user: User) {
        return this.http.post(environment.ApiUrlBase + '/api/users', user);
    }

    delete(id: number) {
        return this.http.delete(environment.ApiUrlBase + '/users/${id}');
    }
}
