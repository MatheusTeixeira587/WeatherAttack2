import { loaderReducer } from './loaderReducers';
import { combineReducers } from 'redux';

const rootState = combineReducers({
    loaderReducer,
});

export default rootState;