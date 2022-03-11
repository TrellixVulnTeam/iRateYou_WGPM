import {Injectable} from "@angular/core";
import {User} from "./entities/user";
import {HttpClient} from "@angular/common/http";


@Injectable({
  providedIn: 'root',
})
export class UserService {


  baseURL = "https://localhost:44321/api/User";

  constructor(private http: HttpClient) {
  }


  async GetAllUsers() : Promise<any> {
    return await this.http.get(this.baseURL).toPromise();

  }

  async GetUserById(id: number) : Promise<any> {
    return await this.http.get(this.baseURL + '/' + id).toPromise();
  }

  async AddUser(user: User) {
    return await this.http.post(this.baseURL, user).toPromise();
  }

  async DeleteUser(id: number) {
    return await this.http.delete(this.baseURL + '/' + id).toPromise();
  }

  async UpdateUser(user: User) {
    return await this.http.put(this.baseURL + '/' + user.id, user).toPromise();
  }
}

