import { types } from "../../constants"

export const requestLoginAction = user => ({
    type: types.LOGIN_REQUEST,
    user: user
})

export const onLoginSucessAction = response => ({
    type: types.LOGIN_SUCESS,
    token: response.token,
    user: response.user
})

export const changeFieldAction = event => ({
    type: types.CHANGE_FIELD,
    fieldname: event.target.name,
    value: event.target.value
})

export const requestRegisterAction = user => ({
    type: types.REGISTER_REQUEST,
    user:user
})

export const triggerRegisterDisplayAction = () => ({
    type: types.SHOULD_RENDER_REGISTER,
})

export const requestLogoutAction = () => ({
    type: types.LOGOUT_REQUEST
})