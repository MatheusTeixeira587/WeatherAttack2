import { loaderReducer } from './loaderReducers';
import { authorizationReducer } from './authorizationReducer';
import { combineReducers } from 'redux';

const rootState = combineReducers({
    loaderReducer,
    authorizationReducer,
});

export default rootState;