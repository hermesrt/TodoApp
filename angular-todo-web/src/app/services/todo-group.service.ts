import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, } from "@angular/common/http";
import { Observable } from 'rxjs';
import { TodoGroup } from '../models/TodoGroup';
import { AuthService } from "../services/auth.service";

@Injectable({
  providedIn: 'root'
})
//TODO hacer una clase padre para q
export class TodoGroupService {

  constructor(private httpClient: HttpClient, private authSrv: AuthService) { }

  postGroup(todoGroup: TodoGroup) {
    return this.httpClient.post<TodoGroup>("https://localhost:44368/api/TodoGroup", todoGroup);
  }
  getGroups(userId: number): Observable<TodoGroup[]> {
    const params = new HttpParams().set("UserId", userId.toString());
    return this.httpClient.get<TodoGroup[]>("https://localhost:44368/api/TodoGroup/", {
      params: params
    });
  }
  deleteGroup(id: number): Observable<any> {
    return this.httpClient.delete<any>(`https://localhost:44368/api/TodoGroup/${id}`)
  }

  putGroup(todoGroup: TodoGroup) {
    return this.httpClient.put<TodoGroup>(`https://localhost:44368/api/TodoGroup/${todoGroup.id}`, todoGroup);
  }
}
