import { loaderReducer } from './loaderReducers';
import { authorizationReducer } from './authorizationReducer';
import { loginPageReducer } from './loginPageReducer';
import { combineReducers } from 'redux';

const rootState = combineReducers({
    loaderReducer,
    authorizationReducer,
    loginPageReducer,
});

export default rootState;