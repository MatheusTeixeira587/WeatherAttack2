import { takeLatest, put } from 'redux-saga/effects'
import { assignLocationAction, assignWeatherDataAction } from '../../actions';
import { WeatherService, GeolocationService } from "../../services";
import { types } from '../../constants';



const weatherService = new WeatherService();
const geolocationService = new GeolocationService();

function* getWeatherSaga() {
    debugger
    const location = yield geolocationService.get();

    yield put(assignLocationAction(location));

    const response = yield weatherService.get({
        latitude: location.latitude,
        longitude: location.longitude
    })

    yield put(assignWeatherDataAction(response));
}

export function* watchGetWeatherSaga() {
    yield takeLatest(types.GET_LOCATION, getWeatherSaga);
}