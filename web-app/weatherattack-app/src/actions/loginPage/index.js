import { LOGIN_REQUEST } from "../../constants";
import { CHANGE_FIELD } from "../../constants/loginPageStates";

export const requestLoginAction = () => ({
    type: LOGIN_REQUEST
})

export const changeField = (fieldname, value) => ({
    type: CHANGE_FIELD,
    fieldname: fieldname,
    value: value
})