import { BaseService } from "../_base"

export class UserService extends BaseService {
    
    constructor() {
        super("api/User")
    }

    add(command) {
        this.post({
            user: command
        })
    }
}