import { LOGIN_REQUEST, CHANGE_FIELD, REGISTER_REQUEST, SHOULD_RENDER_REGISTER} from "../../constants";
import { LoginService, UserService } from "../../services";

const initialState = {
    username:"",
    password:"",
    email:"",
    confirmPassword:"",
    shouldRenderRegister: false
}

const loginService = new LoginService();
const userService = new UserService();

export function loginPageReducer(state = initialState, action){

    switch(action.type) {

        case LOGIN_REQUEST:
            const login = () => {
                loginService.login({
                    username: state.username,
                    password: state.password
                })

                return Object.assign({}, state, initialState)
            }
            
            return login();

        case REGISTER_REQUEST:
            const register = () => {
                userService.add({
                    username: state.username,
                    email: state.email,
                    password: state.password
                })

                return Object.assign({}, state, initialState)
            }

            return register();

        case CHANGE_FIELD:
            return Object.assign({}, state, {
                [action.fieldname]: action.value
            })

        case SHOULD_RENDER_REGISTER:
            return Object.assign({}, state, {
                shouldRenderRegister: !state.shouldRenderRegister
            })

        default:
            return state
    }
}