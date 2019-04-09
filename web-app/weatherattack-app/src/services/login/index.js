import { BaseService } from "../_base";

export class LoginService extends BaseService {
    
    constructor() {
        super("api/Authentication");
    }

    login(user) {
        this.post(user).then(result => {
            localStorage.setItem("logged_user", result.token);
        })   
    }
}