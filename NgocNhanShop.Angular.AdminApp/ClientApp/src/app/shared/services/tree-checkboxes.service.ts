import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { TodoItemNode } from "../components/tree-checkboxes/tree-checkboxes.component";
import { RequestBase } from "src/app/models/request-base";
import { ResponseApi } from "src/app/models/response-api";
import { PagingResponseApi } from "src/app/models/paging-response-api";
import { Action } from "src/app/models/action";
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { map } from "rxjs/operators";

/**
 * Checklist database, it can build a tree structured Json object.
 * Each node in Json object represents a to-do item or a category.
 * If a node is a category, it has children items and new items can be added under the category.
 */

 /**
 * The Json object for to-do list data.
 */

@Injectable({ providedIn: 'root' })
export class TreeCheckBoxesService {
  dataChange = new BehaviorSubject<TodoItemNode[]>([])
  get data(): TodoItemNode[] { return this.dataChange.value; }

  constructor(private http: HttpClient) {
    let request = new RequestBase
    this.getAll(request);
  }

  // initialize() {
  //   // Build the tree nodes from Json object. The result is a list of `TodoItemNode` with nested
  //   //     file node as children.
  //   const data = this.buildFileTree(this.TREE_DATA, 0);

  //   // Notify the change.
  //   this.dataChange.next(data);
  // }

  /**
   * Build the file structure tree. The `value` is the Json object, or a sub-tree of a Json object.
   * The return value is the list of `TodoItemNode`.
   */
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

  updateItem(node: TodoItemNode, name: string) {
    node.item = name;
    this.dataChange.next(this.data);
  }

  getAll(request:RequestBase) {
      return this.http.get<ResponseApi<PagingResponseApi<Action[]>>>(environment.ApiUrlBase 
          + '/api/action/GetAllPaging?pageIndex=' + request.pageIndex +'&pageSize=' + request.pageSize +'&keyword=' + request.keyword).pipe(
          map(res=>{
              let actions:any
              res.resultObj.items.forEach(item => {
                let controllerName = item.controllerName
                actions = {
                  asasasasa: {
                    'insert': "insert",
                    'update': "update",
                    'delete': "delete",
                  },
                };
              });
              if(actions){
              const data = this.buildFileTree(actions, 0);
              // Notify the change.
              this.dataChange.next(data);
              }
              res.resultObj.items = actions
              return res
          })
      );
  }
}
