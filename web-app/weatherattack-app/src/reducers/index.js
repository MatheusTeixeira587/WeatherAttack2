import { loaderReducer } from './loaderReducers';
import { authorizationReducer } from './authorizationReducer';
import { loginPageReducer } from './loginPageReducer';
import { notificationReducer } from './notificationReducer';
import { combineReducers } from 'redux';

const rootState = combineReducers({
    loaderReducer,
    authorizationReducer,
    loginPageReducer,
    notificationReducer,
});

export default rootState;