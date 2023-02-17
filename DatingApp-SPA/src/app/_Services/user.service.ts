import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';


//const httpOptions = {
//  headers: new HttpHeaders({
//    'Authorization': 'Bearer ' + localStorage.getItem('token')
//  })
//};


@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = "https://localhost:44309/api/"

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    /*return this.http.get<User[]>(this.baseUrl + 'users', httpOptions);*/
    return this.http.get<User[]>(this.baseUrl + 'users');
  }

  getUser(id: any): Observable<User> {
    /*return this.http.get<User>(this.baseUrl + 'users/' + id, httpOptions);*/
    return this.http.get<User>(this.baseUrl + 'users/' + id);
  }
}
