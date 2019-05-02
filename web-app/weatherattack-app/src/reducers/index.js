import { loaderReducer } from './loaderReducers';
import { authorizationReducer } from './authorizationReducer';
import { loginPageReducer } from './loginPageReducer';
import { notificationReducer } from './notificationReducer';
import { geolocationReducer } from './geolocationReducer'; 
import {weatherReducer } from './weatherReducer';
import { combineReducers } from 'redux';

const rootState = combineReducers({
    loaderReducer,
    authorizationReducer,
    loginPageReducer,
    notificationReducer,
    geolocationReducer,
    weatherReducer
});

export default rootState;