import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { ResponseApi } from '../models/response-api';
import { PagingResponseApi } from '../models/paging-response-api';
import { Action } from '../models/action';
import { RequestBase } from '../models/request-base';


@Injectable({ providedIn: 'root' })
export class ActionService {
    constructor(private http: HttpClient) { }

    getAll(request:RequestBase) {
        return this.http.get<ResponseApi<PagingResponseApi<Action[]>>>(environment.ApiUrlBase 
            + '/api/action/GetAllPaging?pageIndex=' + request.pageIndex +'&pageSize=' + request.pageSize +'&keyword=' + request.keyword).pipe(
            map(res=>{
                const actions: Action[] = [];
                res.resultObj.items.forEach(item => {
                    actions.push(new Action(item));
                });
                res.resultObj.items = actions
                return res
            })
        );
    }
    getById(idAction : string) {
        return this.http.get<ResponseApi<Action>>(environment.ApiUrlBase + '/api/action/getbyactionid/'+ idAction).pipe(
            map(res=>{
                res.resultObj = new Action( res.resultObj);
                return res
            })
        );
    }

    register(action: Action) {
        return this.http.post<ResponseApi<boolean>>(environment.ApiUrlBase + '/api/action/render', action);
    }

    edit(idAction : string, action: Action) {
        return this.http.put<ResponseApi<boolean>>(environment.ApiUrlBase + '/api/action/update/'+ idAction, action);
    }

    delete(idAction: string) {
        return this.http.delete(environment.ApiUrlBase + '/api/action/delete/'+ idAction);
    }
}
