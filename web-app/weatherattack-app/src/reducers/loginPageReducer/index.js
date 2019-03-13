import { LOGIN_REQUEST } from "../../constants";
import { LoginService } from "../../services/login";
import { CHANGE_FIELD } from "../../constants/loginPageStates";

const initialState = {
    username:"",
    password:""
}

export function loginPageReducer(state = initialState, loginService = new LoginService(), action){
    switch(action.type) {

        case LOGIN_REQUEST:
            return () => {
                loginService.login({
                    username: this.state.username,
                    password: this.state.password
                }).then(resolve => {
                    console.log(resolve)
                }).catch(err => {
                    console.error(err)
                })
            }

        case CHANGE_FIELD:
            return Object.assign({}, state, {
                [action.fieldname]: action.value
            })

        default:
            return state
    }
}