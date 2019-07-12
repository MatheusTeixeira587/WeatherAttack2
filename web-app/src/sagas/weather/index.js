import { takeLatest, put } from 'redux-saga/effects'
import { assignLocationAction, assignWeatherDataAction, addNotificationAction } from '../../actions';
import { WeatherService, GeolocationService } from "../../services";
import { types, LOCATION_PERMISSION_DENIED, LOCATION_UNAVAILABLE, LOCATION_UNKNOWN_ERROR, LOCATION_TIMEOUT } from '../../constants';

const weatherService = new WeatherService();
const geolocationService = new GeolocationService();

function* getWeatherSaga() {
    const location = yield geolocationService.get();

    if(!location.error) {
        put(assignLocationAction(location));

        try {
            const response = yield weatherService.get({
                latitude: location.latitude,
                longitude: location.longitude
            })
            
            yield put(assignWeatherDataAction(response));

        } catch(e) {
            console.error(e);
        }
        
    } else {
        yield put(addNotificationAction(_handleError(location.error)));
    }
}

function _handleError(error) {
    switch(error.code) {
        case error.PERMISSION_DENIED:
          return LOCATION_PERMISSION_DENIED;
        case error.POSITION_UNAVAILABLE:
            return LOCATION_UNAVAILABLE;
        case error.TIMEOUT:
            return LOCATION_TIMEOUT;
        case error.UNKNOWN_ERROR:
            return LOCATION_UNKNOWN_ERROR;
        default:
            return LOCATION_UNKNOWN_ERROR;
      }
}

export function* watchGetWeatherSaga() {
    yield takeLatest(types.GET_LOCATION, getWeatherSaga);
}