import { inject, Injectable } from '@angular/core';
import { User } from '../interfaces/user';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  currentUser:BehaviorSubject<User>= new BehaviorSubject<User>({} as User);
  http:HttpClient=inject(HttpClient);
  url = "https://localhost:7186/user/";

  login(user:User):Observable<User>{
    return this.http.post<User>(this.url+"login/",user);
  }

  register(user:User):Observable<User>{
    debugger
    return this.http.post<User>(this.url+"register/",user);
  }

  checkExist(userId:number){
    return this.http.get<boolean>(this.url+"checkExisting")
  }
}
