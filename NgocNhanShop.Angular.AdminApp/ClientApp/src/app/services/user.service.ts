import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { map, catchError } from 'rxjs/operators';
import { ResponseApi } from '../models/response-api';
import { ResponseError } from '../models/response-error';


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
        return this.http.post<ResponseApi<boolean>>(environment.ApiUrlBase + '/api/users', user).pipe(
          map(res => {
            const listError: ResponseError[] = [];
            res.listError.forEach(item => {
              listError.push(new ResponseError(item));
            });
            res.listError = listError;
            return res
          }),
          catchError((err, caught) => {
            return caught;
          })
        );
    }

    delete(id: number) {
        return this.http.delete(environment.ApiUrlBase + '/users/${id}');
    }
}
