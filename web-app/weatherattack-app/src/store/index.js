import { createStore } from 'redux';
import rootState from '../reducers';

const store = createStore(rootState);

export default store;