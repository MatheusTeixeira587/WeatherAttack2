import { BaseService } from "../_base"

export class LoginService extends BaseService {
    
    constructor() {
        super("api/Authentication")

        this.login = this.login.bind(this)
        this._parseToken = this._parseToken.bind(this)
    }

    login(user) {
        return this.post(user).then(result => {

            const user = this._parseToken(result.token)
            
            return { token: result.token, user }
        })   
    }

    _parseToken(token) {
        const parsed = Object.values(JSON.parse(window.atob(token.split(".")[1])))

        return {
            id: parsed[0],
            username: parsed[1],
            permissionLevel: parsed[2],
        }
    }
}