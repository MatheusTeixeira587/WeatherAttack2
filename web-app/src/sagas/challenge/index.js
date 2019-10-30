import { call, takeEvery, take, race, select, put, all } from "redux-saga/effects"
import { HubService } from "../../services"
import { types, challengeEvents } from "../../constants"
import { userReceivedChallengeAction, removeChallengeAction } from "../../actions"
import { HubConnectionState } from "@aspnet/signalr"


const challengeEventsArray = Object.values(challengeEvents)

function* listenServerSaga(hubChannel) {
    try {
        while(true) {
            console.info("waiting for upcoming messages...") 
            const action = yield take(hubChannel)
            action.dispatchedByServer = true
            yield put(action)
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
            if (!action.dispatchedByServer && hub.connection.state === HubConnectionState.Connected) {
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
        console.log("hub ->")
        console.log(hub)
        if (hub.connection.state === HubConnectionState.Connected) {
            hub.invoke(challengeEvents.USER_LEFT_CHANNEL, { id }).then(r => hub.stop())
        }
    } catch {
        console.log("connection closed...")
    }
}

function* challengeInviteSaga() {
    try {
        const userId = yield select(state => state.loginReducer.id)
        while(true) {
            const action = yield take(challengeEvents.CHALLENGE_USER)
            if(action.command.to.id === userId) {
                yield put(userReceivedChallengeAction(action.command))
            }
        }
    } catch {
    }
}

function* removeChallengeInviteSaga() {
    try {
        const userId = yield select(state => state.loginReducer.id)
        while(true) {
            const action = yield take([challengeEvents.ACCEPT_CHALLENGE, challengeEvents.REFUSE_CHALLENGE])
            if(action.command.to.id === userId) {
                yield put(removeChallengeAction(action.command))
            }
        }
    } catch {
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
                call(challengeInviteSaga),
                call(removeChallengeInviteSaga)
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