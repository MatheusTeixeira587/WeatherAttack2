import { takeLatest, put, all } from 'redux-saga/effects'
import { LoginService, UserService } from '../../services'
import { types } from '../../constants';
import { onLoginSucessAction, requestLoginAction, startChannelAction, closeChannelAction, getCharacterAction } from '../../actions'

const loginService = new LoginService();
const userService = new UserService();

function* loginSaga(action) {
    const response = yield loginService.login(action.user);
    localStorage.setItem("logged_user", response.token)
 
    yield all([
        put(onLoginSucessAction(response)),
        put(startChannelAction()),
        put(getCharacterAction()),
    ])
}

function* registerSaga(action) {
    const response = yield userService.post({user:action.user});

    if (!!response.notifications.length) {
        return;
    }

    yield put(requestLoginAction(response.user))
}

function* logoutSaga() {
    localStorage.removeItem("logged_user");

    yield put(closeChannelAction())
}

export function* watchLoginSaga() {
    yield takeLatest(types.LOGIN_REQUEST, loginSaga);
    yield takeLatest(types.REGISTER_REQUEST, registerSaga);
    yield takeLatest(types.LOGOUT_REQUEST, logoutSaga);
}