import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { map, catchError } from 'rxjs/operators';
import { ResponseApi } from '../models/response-api';
import { PagingResponseApi } from '../models/paging-response-api';
import { RequestBase } from '../models/request-base';


@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    getAll(request:RequestBase) {
        return this.http.get<ResponseApi<PagingResponseApi<User[]>>>(environment.ApiUrlBase 
            + '/api/users/GetAllPaging?pageIndex=' + request.pageIndex +'&pageSize=' + request.pageSize +'&keyword=' + request.keyword).pipe(
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
    getById(idUser : string) {
        return this.http.get<ResponseApi<User>>(environment.ApiUrlBase + '/api/users/getbyuserid/'+ idUser).pipe(
            map(res=>{
                res.resultObj = new User( res.resultObj);
                return res
            })
        );
    }

    getDetail(idUser : string) {
        return this.http.get<ResponseApi<User>>(environment.ApiUrlBase + '/api/users/detail/'+ idUser).pipe(
            map(res=>{
                res.resultObj = new User( res.resultObj);
                return res
            })
        );
    }

    register(user: User) {
        return this.http.post<ResponseApi<boolean>>(environment.ApiUrlBase + '/api/users/register', user);
    }

    edit(idUser : string, user: User) {
        return this.http.put<ResponseApi<boolean>>(environment.ApiUrlBase + '/api/users/update/'+ idUser, user);
    }

    delete(idUser: string) {
        return this.http.delete(environment.ApiUrlBase + '/api/users/delete/'+ idUser);
    }
}
