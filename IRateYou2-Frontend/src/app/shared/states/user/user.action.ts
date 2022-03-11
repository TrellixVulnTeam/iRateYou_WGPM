import {User} from "./entities/user";

export class GetAllUsers {
  static readonly type = 'getallusers';
}

export class GetUserById {
  static readonly type = 'getuserbyid';
  constructor(public id: number){

  }
}

export class AddUser{
  static readonly type = 'adduser';
  constructor(public user: User) {
  }
}

export class DeleteUser{
  static readonly type = 'deleteuser';
  constructor(public id: number){
  }
}

export class UpdateUser{
  static readonly type = 'updateuser';
  constructor( public user: User) {
  }
}



