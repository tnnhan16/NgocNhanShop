import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from "rxjs/operators";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }
  getUserRepos(): Observable<any> {
    return this.httpClient.get('https://api.github.com/users/mithunvp/repos').
      pipe(
        map((item: any) => item.map(p => <any>
          {
            name: p.name,
            stars: p.stargazers_count,
            htmlUrl: p.html_url,
            forks: p.forks,
            description: p.description
          })));
  }
}
