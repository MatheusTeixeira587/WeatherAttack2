import { types } from "../../constants";

const initialState = {
    username:"",
    password:"",
    email:"",
    confirmPassword:"",
    shouldRenderRegister: false,
    token: localStorage.getItem("logged_user")
}

export function loginReducer(state = initialState, action){

    switch(action.type) {

        case types.LOGIN_SUCESS:
            return Object.assign({}, state, {
                token: action.token
            })

        case types.REGISTER_REQUEST:
            return Object.assign({}, state, initialState)

        case types.LOGOUT_REQUEST:
            return Object.assign({}, state, {
                token: null
            })

        case types.CHANGE_FIELD:
            return Object.assign({}, state, {
                [action.fieldname]: action.value
            })

        case types.SHOULD_RENDER_REGISTER:
            return Object.assign({}, state, {
                shouldRenderRegister: !state.shouldRenderRegister
            })

        default:
            return state
    }
}