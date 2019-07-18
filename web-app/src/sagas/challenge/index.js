import { call, takeEvery, take, race, select, put, all, takeLatest } from "redux-saga/effects"
import { HubService } from "../../services"
import { types, challengeEvents } from "../../constants"

const challengeEventsArray = Object.values(challengeEvents)

function* challengeInviteSaga(action) {
    try {
        const userId = yield select(state => state.loginReducer.id)
        if (action.to.id === userId) {
            yield put(types)
        }
    } catch (e) {
        console.log(e)
    }
}


function* listenServerSaga(hubChannel) {
    try {
        while(true) {
            console.info("waiting for upcoming messages...") 
            const payload = yield take(hubChannel)
            console.info("received:")
            console.info(payload)
            payload.dispatchedByServer = true
            yield put(payload)
        }
    } catch(e) {
        console.error(e)
    }
}

function* sendToServerSaga(hub) {
    try {
        while(true) {
            console.info("waiting to send messages...")
            const action = yield take(challengeEventsArray)
            if (!action.dispatchedByServer) {
                hub.invoke(action.type, action.command)
            }
        }
    } catch (e) {
        console.error(e)
    }
}

function* closeConnectionSaga(hub) {
    yield take(types.STOP_CHALLENGE_CHANNEL)
    const id = yield select(state => state.loginReducer.id)
    try {
        hub.invoke(challengeEvents.USER_LEFT_CHANNEL, { id }).then(r => hub.stop())
    } catch {
        console.log("connection closed...")
    }
}

function* startConnectionSaga() {
    try {
        console.info("starting connection...")
        const token = yield select(state => state.loginReducer.token)    
        const hub = yield call(HubService.connect, token, "challenge")
        const hubChannel = yield call(HubService.createHubChannel, hub)
        
        yield race({
            task: all([
                call(listenServerSaga, hubChannel), 
                call(sendToServerSaga, hub),
                takeLatest(challengeEvents.CHALLENGE_USER, challengeInviteSaga)
                ]),
            cancel: call(closeConnectionSaga, hub)
            })
    } catch(e) {
        console.error(e)
    }
}

export function* watchListenServerSaga() {
    yield takeEvery(types.START_CHALLENGE_CHANNEL, startConnectionSaga)
}