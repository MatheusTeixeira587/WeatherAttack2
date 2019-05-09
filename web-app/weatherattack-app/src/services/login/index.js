import { BaseService } from "../_base";

export class LoginService extends BaseService {
    
    constructor() {
        super("api/Authentication");

        this.login = this.login.bind(this);
    }

    login(user) {
        return this.post(user).then(result => {
            return result.token
        })   
    }
}