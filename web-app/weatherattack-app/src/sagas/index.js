import { all } from 'redux-saga/effects'
import { watchLoginSaga } from './login'
import { watchGetWeatherSaga } from './weather'

export default function* rootSaga() {
    yield all([
        watchLoginSaga(),
        watchGetWeatherSaga()
    ]);
}