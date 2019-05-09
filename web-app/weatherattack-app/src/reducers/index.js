import { loaderReducer } from './loaderReducers';
import { loginReducer } from './loginReducer';
import { notificationReducer } from './notificationReducer';
import { geolocationReducer } from './geolocationReducer'; 
import { weatherReducer } from './weatherReducer';
import { combineReducers } from 'redux';

const rootState = combineReducers({
    loaderReducer,
    loginReducer,
    notificationReducer,
    geolocationReducer,
    weatherReducer
});

export default rootState;