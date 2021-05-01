import { Injectable } from '@angular/core';
import { HttpClient, } from "@angular/common/http";
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
    return this.httpClient.post("https://localhost:44368/api/TodoGroup", todoGroup);
  }
  getGroups(): Observable<TodoGroup[]> {
    return this.httpClient.get<TodoGroup[]>("https://localhost:44368/api/TodoGroup");
  }
  deleteGroup(id: number): Observable<any> {
    return this.httpClient.delete<any>(`https://localhost:44368/api/TodoGroup/${id}`)
  }
}
