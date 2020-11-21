import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;
  users: any;

  constructor(private http: HttpClient) { }

  getUsers(){
    return this.http.get<User[]>(this.baseUrl + 'users');
  }

  getUserByUserName(userName: string){
    return this.http.get<User>(this.baseUrl + 'users/' + userName);
  }

  updateUser(user: User){
    return this.http.put(this.baseUrl + 'users', user);
  }
}
