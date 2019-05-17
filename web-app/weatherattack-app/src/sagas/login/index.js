import { takeLatest, put } from 'redux-saga/effects'
import { LoginService, UserService } from '../../services'
import { types } from '../../constants';
import { onLoginSucessAction, requestLoginAction, startChannelAction, closeChannelAction } from '../../actions'

const loginService = new LoginService();
const userService = new UserService();

function* loginSaga(action) {
    const response = yield loginService.login(action.user);
    localStorage.setItem("logged_user", response)
 
    yield put(onLoginSucessAction(response))
}

function* registerSaga(action) {
    const response = yield userService.post({user:action.user});

    if (!!response.notifications.length) {
        return;
    }

    yield [
        put(requestLoginAction(response.user)),
        put(startChannelAction())
    ]
}

function* logoutSaga(action) {
    localStorage.removeItem("logged_user");

    yield put(closeChannelAction())
}

export function* watchLoginSaga() {
    yield takeLatest(types.LOGIN_REQUEST, loginSaga);
    yield takeLatest(types.REGISTER_REQUEST, registerSaga);
    yield takeLatest(types.LOGOUT_REQUEST, logoutSaga);
}