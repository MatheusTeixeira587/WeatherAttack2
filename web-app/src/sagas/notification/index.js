import { takeEvery, put, delay } from 'redux-saga/effects'
import { types } from '../../constants'
import { removeNotificationAction } from '../../actions'

function* removeNotificationSaga(action) {
    yield delay(4000)
    yield put(removeNotificationAction(action.notification))
}


export function* watchNotificationSaga() {
    yield takeEvery(types.ADD_NOTIFICATION, removeNotificationSaga);
}