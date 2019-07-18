import { HIDE_LOADER, SHOW_LOADER } from "./loader"
import { ASSIGN_WEATHER_DATA } from "./weatherStates"
import { GET_LOCATION , ASSIGN_LOCATION} from "./geolocation"
import { REGISTER_REQUEST, LOGIN_REQUEST, LOGOUT_REQUEST, SHOULD_RENDER_REGISTER, CHANGE_FIELD, LOGIN_SUCESS } from "./login"
import { ADD_NOTIFICATION, REMOVE_NOTIFICATION } from "./notificationStates"
import { START_CHALLENGE_CHANNEL, STOP_CHALLENGE_CHANNEL } from "./socket"
import { GET_CHARACTER, ASSIGN_CHARACTER } from "./character"
import { NOT_FOUND, LOGIN_PAGE, DASHBOARD_PAGE, ADMINISTRATION_PAGE } from "./routes"
import { USER, ADMIN } from "./permissions"
import { ADD_RULE, REMOVE_RULE, CHANGE_RULE } from "./rules"
import { ADD_SPELL } from "./spell"
import { GET_PAGED_USERS, ASSIGN_PAGED_USERS, CHANGE_ROWS_PAGE } from "./userArea"
import { USER_RECEIVED_CHALLENGE } from "./challenge"
import { CHANGE_LANGUAGE } from "./language"

export * from "./colors"
export * from "./notifications"
export * from "./messages"
export * from "./socket"
export * from "./spell"
export { weatherConditions, operators} from "./rules"
export { supportedLanguages } from "./language"

export const types = {
    HIDE_LOADER, SHOW_LOADER,
    ASSIGN_WEATHER_DATA,
    GET_LOCATION, ASSIGN_LOCATION,
    REGISTER_REQUEST, LOGIN_REQUEST, LOGOUT_REQUEST, SHOULD_RENDER_REGISTER, CHANGE_FIELD, LOGIN_SUCESS,
    ADD_NOTIFICATION, REMOVE_NOTIFICATION,
    START_CHALLENGE_CHANNEL, STOP_CHALLENGE_CHANNEL,
    GET_CHARACTER, ASSIGN_CHARACTER,
    ADD_RULE, REMOVE_RULE, CHANGE_RULE,
    ADD_SPELL,
    GET_PAGED_USERS, ASSIGN_PAGED_USERS, CHANGE_ROWS_PAGE,
    USER_RECEIVED_CHALLENGE,
    CHANGE_LANGUAGE
}

export const routes = {
    NOT_FOUND,
    LOGIN_PAGE, 
    DASHBOARD_PAGE,
    ADMINISTRATION_PAGE,
}

export const permissionLevel = {
    USER,
    ADMIN
}