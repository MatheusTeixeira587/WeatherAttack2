import { createStore, applyMiddleware } from 'redux';
import rootState from '../reducers';
import createSagaMiddleware from 'redux-saga';
import rootSaga from '../sagas';

const sagaMiddleware = createSagaMiddleware();

const store = createStore(rootState, applyMiddleware(sagaMiddleware));

sagaMiddleware.run(rootSaga);

export default store;