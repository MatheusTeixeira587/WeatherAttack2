import { call, take, race, select, put } from 'redux-saga/effects'
import { HubService } from '../../services';
import { types } from '../../constants';

let token, hub, hubChannel;

function* listenServerSaga() {

    console.log('starting connection...');
    token = yield select(state => state.loginReducer.token);    
    hub = yield call(HubService.connect, token, "challenge");
    hubChannel = yield call(HubService.createHubChannel, hub);

    while(true) {
        console.log('waiting for upcoming messages...');        
        const payload = yield take(hubChannel);
        console.log(payload);
        yield put(payload);
    }
}

function* closeConnectionSaga() {
    debugger
    yield put(hubChannel, types.STOP_CHANNEL);
}


export function* watchListenServerSaga() {
    while(true) {
        yield take(types.START_CHANNEL);
        yield race({
            task: call(listenServerSaga)
        },{
            task: take(types.STOP_CHANNEL, closeConnectionSaga)
        })
    }
}