import { Component, OnInit } from '@angular/core';
import {Select, Store} from "@ngxs/store";
import {Observable} from "rxjs";
import {GetAllUsers, GetUserById} from "../shared/states/user/user.action";
import {UserState} from "../shared/states/user/user.state";
import {User} from "../shared/states/user/entities/user";
import {Router} from "@angular/router";

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {

  // @ts-ignore
  @Select(UserState.getAllUsers) allUsers: Observable<User[]>;

  // @ts-ignore
  users: User[];

  // @ts-ignore
  @Select(UserState.getUserById) singleUser: Observable<User>;

  constructor(private store: Store, private router: Router) {
    // @ts-ignore
    this.allUsers.subscribe((data)=> {
      this.users = data;
      console.table(data);
    });
    store.dispatch(new GetAllUsers());

    // @ts-ignore
    this.singleUser.subscribe((data)=> {
      console.log(data);
    });
    store.dispatch(new GetUserById(3));


  }

  ngOnInit(): void {
  }

}
