import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { map, catchError } from 'rxjs/operators';
import { ResponseApi } from '../models/response-api';
import { PagingResponseApi } from '../models/paging-response-api';


@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<ResponseApi<PagingResponseApi<User[]>>>(environment.ApiUrlBase + '/api/users/paging').pipe(
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
    getById(idUser : any) {
        return this.http.get<ResponseApi<User>>(environment.ApiUrlBase + '/api/users/byid/'+ idUser).pipe(
            map(res=>{
                res.resultObj = new User( res.resultObj);
                return res
            })
        );
    }

    register(user: User) {
        return this.http.post<ResponseApi<boolean>>(environment.ApiUrlBase + '/api/users', user);
    }

    delete(id: number) {
        return this.http.delete(environment.ApiUrlBase + '/users/${id}');
    }
}
