import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { map, catchError } from 'rxjs/operators';
import { ResponseApi } from '../models/response-api';
import { PagingResponseApi } from '../models/paging-response-api';
import { Role } from '../models/role';
import { RequestBase } from '../models/request-base';


@Injectable({ providedIn: 'root' })
export class RoleService {
    constructor(private http: HttpClient) { }

    getAll(request : RequestBase) {
        return this.http.get<ResponseApi<PagingResponseApi<Role[]>>>(environment.ApiUrlBase 
            + '/api/role/GetAllPaging?pageIndex=' + request.pageIndex +'&pageSize=' + request.pageSize +'&keyword=' + request.keyword).pipe(
            map(res=>{
                const roles: Role[] = [];
                res.resultObj.items.forEach(item => {
                    roles.push(new Role(item));
                });
                res.resultObj.items = roles
                return res
            })
        );
    }
    getById(idRole : string) {
        return this.http.get<ResponseApi<Role>>(environment.ApiUrlBase + '/api/role/getbyroleid/'+ idRole).pipe(
            map(res=>{
                res.resultObj = new Role( res.resultObj);
                return res
            })
        );
    }

    register(role: Role) {
        return this.http.post<ResponseApi<boolean>>(environment.ApiUrlBase + '/api/role/register', role);
    }

    edit(idRole : string, role: Role) {
        return this.http.put<ResponseApi<boolean>>(environment.ApiUrlBase + '/api/role/update/'+ idRole, role);
    }

    delete(idRole: string) {
        return this.http.delete(environment.ApiUrlBase + '/api/role/delete/'+ idRole);
    }
}
