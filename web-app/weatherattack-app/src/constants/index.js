import { HIDE_LOADER, SHOW_LOADER } from './loaderStates'
import { ASSIGN_WEATHER_DATA } from './weatherStates'
import { GET_LOCATION , ASSIGN_LOCATION} from './geolocationStates'
import { REGISTER_REQUEST, LOGIN_REQUEST, LOGOUT_REQUEST, SHOULD_RENDER_REGISTER, CHANGE_FIELD, LOGIN_SUCESS } from './loginStates'
import { ADD_NOTIFICATION, REMOVE_NOTIFICATION } from './notificationStates'
import { START_CHANNEL, STOP_CHANNEL } from './socket'
import { GET_CHARACTER, ASSIGN_CHARACTER } from './character'
import {  NOT_FOUND, LOGIN_PAGE, DASHBOARD_PAGE, ADMINISTRATION_PAGE } from './routes'
import { USER, ADMIN } from './permissions'

export * from './colors'
export * from './appNotifications'
export * from './messages'
export * from './socket'
export * from './spell'

export const types = {
    HIDE_LOADER, SHOW_LOADER,
    ASSIGN_WEATHER_DATA,
    GET_LOCATION, ASSIGN_LOCATION,
    REGISTER_REQUEST, LOGIN_REQUEST, LOGOUT_REQUEST, SHOULD_RENDER_REGISTER, CHANGE_FIELD, LOGIN_SUCESS,
    ADD_NOTIFICATION, REMOVE_NOTIFICATION,
    START_CHANNEL, STOP_CHANNEL,
    GET_CHARACTER, ASSIGN_CHARACTER
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