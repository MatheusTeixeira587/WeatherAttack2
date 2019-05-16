import { call, take, race, select, put } from 'redux-saga/effects'
import { HubService } from '../../services';
import { types } from '../../constants';

function* listenServerSaga() {

    const token = yield select(state => state.loginReducer.token);    
    const hub = yield call(HubService.connect, token, "challenge");
    const hubChannel = yield call(HubService.createHubChannel, hub);

    while(true) {
        console.log('waiting for upcoming messages...');        
        const payload = yield take(hubChannel);

        console.log(payload);

        yield put(payload);
    }
}

export function* watchListenServerSaga() {
    while(true) {
        yield take(types.START_CHANNEL);
        yield race({
            task: call(listenServerSaga),
            cancel: take(types.STOP_CHANNEL),
        })
    }
}