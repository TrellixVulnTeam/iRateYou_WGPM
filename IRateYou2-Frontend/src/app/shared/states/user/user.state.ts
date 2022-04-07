import {Action, Selector, State, StateContext} from "@ngxs/store";
import {Injectable} from "@angular/core";
import {UserService} from "./user.service";
import {AddUser, DeleteUser, GetAllUsers, GetUserById, UpdateUser} from "./user.action";
import {User} from "./entities/user";


export class UserStateModel {
  // @ts-ignore
  allUsers: User[];
  // @ts-ignore
  singleUser : User;
}

@State<UserStateModel> ({
  name: 'user',
  defaults: {
    // @ts-ignore
    allUsers: undefined,
    // @ts-ignore
    singleUser: undefined
  }
})
@Injectable()
export class UserState {
  constructor(private userService: UserService) {

  }

  @Selector()
  static getAllUsers(state: UserStateModel): any {
    return state.allUsers;
  }

  @Selector()
  static getUserById(state: UserStateModel): any {
    return state.singleUser;
  }

  @Action(GetAllUsers)
  getAllUsers({getState, setState}: StateContext<UserStateModel>, {}: GetAllUsers): any {
    return this.userService.GetAllUsers().then((result) => {
      console.log(result);
      const state = getState();
      setState({
        ...state,
        // @ts-ignore
        allUsers: result
      })
    })
  }

  @Action(GetUserById)
  getUserById({getState, setState}: StateContext<UserStateModel>, {id}: GetUserById): any {
    return this.userService.GetUserById(id).then((result) => {
      const state = getState();
      setState({
        ...state,
        // @ts-ignore
        singleUser: result
      })
    })
  }

  @Action(AddUser)
  addUser({getState, setState}: StateContext<UserStateModel>, {user}: AddUser): any {
    return this.userService.AddUser(user);
  }

  @Action(DeleteUser)
  deleteUser({getState, setState}: StateContext<UserStateModel>, {id}: DeleteUser): any {
    return this.userService.DeleteUser(id);
  }

  @Action(UpdateUser)
  updateUser({getState, setState}: StateContext<UserStateModel>, { user}: UpdateUser): any {
    return this.userService.UpdateUser(user);
  }
}
