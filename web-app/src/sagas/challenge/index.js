import { call, takeLeading, take, race, select, put, fork } from 'redux-saga/effects'
import { HubService } from '../../services';
import { types, challengeEvents } from '../../constants';

function* listenServerSaga(hubChannel, hub) {
    try {
        yield fork(sendToServerSaga, hubChannel, hub);
        while(true) {
            console.log('waiting for upcoming messages...');        
            const payload = yield take(hubChannel);
            yield put(payload);
        }
    } catch(e) {
        console.error(e);
    }
}

function* sendToServerSaga(hubChannel, hub) {
    while(true) {
        console.log('waiting to send messages...');  
        const action = yield take(
            [
                challengeEvents.CHALLENGE_USER, 
                challengeEvents.ACCEPT_CHALLENGE, 
                challengeEvents.REFUSE_CHALLENGE
            ])

        const resp = hub.invoke(action.type, action.command);
        yield put(resp);
    }
}

function* closeConnectionSaga(hubChannel) {
    yield put(hubChannel, types.STOP_CHANNEL);
}

function* startConnectionSaga() {
    try {
        console.log('starting connection...');
        const token = yield select(state => state.loginReducer.token);    
        const hub = yield call(HubService.connect, token, "challenge");
        const hubChannel = yield call(HubService.createHubChannel, hub);
        debugger

        while(true) {
            yield race({
                task: call(listenServerSaga, hubChannel, hub)
            },{
                task: take(types.STOP_CHANNEL, closeConnectionSaga)
            })
        }
    } catch(e) {
        console.log(e);
    }
}

export function* watchListenServerSaga() {
    yield takeLeading(types.START_CHANNEL, startConnectionSaga);
}