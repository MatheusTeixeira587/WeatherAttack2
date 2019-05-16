import { all } from 'redux-saga/effects'
import { watchLoginSaga } from './login'
import { watchGetWeatherSaga } from './weather'
import { watchListenServerSaga } from './challenge'

export default function* rootSaga() {
    yield all([
        watchLoginSaga(),
        watchGetWeatherSaga(),
        watchListenServerSaga()
    ]);
}