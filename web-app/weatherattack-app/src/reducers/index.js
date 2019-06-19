import { loaderReducer } from './loaderReducers';
import { loginReducer } from './loginReducer';
import { notificationReducer } from './notificationReducer';
import { geolocationReducer } from './geolocationReducer'; 
import { weatherReducer } from './weatherReducer';
import { challengeReducer } from './challengeReducer';
import { characterReducer } from './characterReducer';
import { rulesReducer } from './rulesReducer';
import { combineReducers } from 'redux';

const rootState = combineReducers({
    loaderReducer,
    loginReducer,
    notificationReducer,
    geolocationReducer,
    weatherReducer,
    challengeReducer,
    characterReducer,
    rulesReducer
});

export default rootState;