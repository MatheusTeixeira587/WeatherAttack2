import { LOGIN_REQUEST, CHANGE_FIELD, REGISTER_REQUEST, SHOULD_RENDER_REGISTER } from "../../constants";

export const requestLoginAction = () => ({
    type: LOGIN_REQUEST
})

export const changeFieldAction = (event) => ({
    type: CHANGE_FIELD,
    fieldname: event.target.name,
    value: event.target.value
})

export const requestRegisterAction = () => ({
    type: REGISTER_REQUEST,
})

export const triggerRegisterDisplayAction = () => ({
    type: SHOULD_RENDER_REGISTER,
})