import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { RequestBase } from 'src/app/models/request-base';
import { Action } from 'src/app/models/action';
import { HttpClient } from '@angular/common/http';
import { ResponseApi } from 'src/app/models/response-api';
import { PagingResponseApi } from 'src/app/models/paging-response-api';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { ControllerNameOption } from 'src/app/models/action/controller-name-option';

/**
 * Node for to-do item
 */
export class TodoItemNode {
  children: TodoItemNode[];
  item: string;
}

@Injectable({ providedIn: 'root' })

export class TreeCheckBoxesService {

  actions = {};
  dataChange = new BehaviorSubject<TodoItemNode[]>([]);
  get data(): TodoItemNode[] { return this.dataChange.value; }

  constructor(private http: HttpClient) {
    this.initialize();
  }

  initialize() {
    const data = this.buildFileTree(this.actions, 0);
    this.dataChange.next(data);
  }

  buildFileTree(obj: {[key: string]: any}, level: number): TodoItemNode[] {
    return Object.keys(obj).reduce<TodoItemNode[]>((accumulator, key) => {
      const value = obj[key];
      const node = new TodoItemNode();
      node.item = key;
      if (value != null) {
        if (typeof value === 'object') {
          node.children = this.buildFileTree(value, level + 1);
        } else {
          node.item = value;
        }
      }
      return accumulator.concat(node);
    }, []);
  }

  getActionOptions() {
    return this.http.get<ResponseApi<ControllerNameOption[]>>(environment.ApiUrlBase + '/api/action/GetActionOptions/').pipe(
        map(res=>{
            const controllerNameOption: ControllerNameOption[] = []
            res.resultObj.forEach(items => {
                controllerNameOption.push(new ControllerNameOption(items))
            });
            if(controllerNameOption){
              const controllerNameOptions = {};
              controllerNameOption.forEach(item => {
                const actionNameOptions = [];
                item.actionNameOptions.forEach(row => {
                  actionNameOptions.push({[row.id]: row.description})
                })
                controllerNameOptions
              })
              console.log(Object.assign({}, controllerNameOptions))
              this.actions = {
                              'home': {
                                'insert1': "insert",
                                'update1': "update",
                                'delete1': "delete",
                              },
                              'home1': {
                                'insert1': "insert",
                                'update1': "update",
                                'delete1': "delete",
                              },
                              'home2': {
                                'insert1': "insert",
                                'update1': "update",
                                'delete1': "delete",
                              },
                              'home3': {
                                'insert1': "insert",
                                'update1': "update",
                                'delete1': "delete",
                              },
                            };
                            console.log(this.actions)
              this.actions = controllerNameOptions;
              const data = this.buildFileTree(this.actions, 0);
              // Notify the change.
                this.dataChange.next(data);
                return data;
            }
            return []
        })
    );
  }
  // get() {
  //   return this.http.get<ResponseApi<PagingResponseApi <Action[]>>>(environment.ApiUrlBase 
  //       + '/api/action/getActionOptions').pipe(
  //       map(res=>{
            
  //           res.resultObj.items.forEach(item => {
  //             let listAction:any
  //             let controllerName = item.controllerName
  //             this.actions = {
  //               'home': {
  //                 'insert': "insert",
  //                 'update': "update",
  //                 'delete': "delete",
  //               },
  //             };
  //             listAction.push();

  //           });
  //           if(this.actions){
  //           const data = this.buildFileTree(this.actions, 0);
  //           // Notify the change.
  //             this.dataChange.next(data);
  //             return data;
  //           }
  //           return [];
  //       })
  //   );
  // }

}