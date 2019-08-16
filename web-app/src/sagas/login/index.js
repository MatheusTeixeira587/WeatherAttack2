import { takeLatest, put, all } from "redux-saga/effects"
import { LoginService, UserService } from "../../services"
import { types } from "../../constants"
import { onLoginSucessAction, requestLoginAction, startChannelAction, closeChannelAction, getCharacterAction } from "../../actions"

const loginService = new LoginService()
const userService = new UserService()

function* loginSaga(action) {
    try {
        const command = yield loginService.login(action.user)
        localStorage.setItem("logged_user", command.token)

        yield all([
            put(onLoginSucessAction(command)),
            put(startChannelAction()),
            put(getCharacterAction()),
        ])
    } catch(e) {
        console.error(e)
    }
}

function* registerSaga(action) {
    try {
        const command = yield userService.post({user:action.user})
        
        if (!!command.notifications.length) {
            return
        }
        
        yield put(requestLoginAction(command.user))
    } catch(e) {
        console.error(e)
    }
}

function* logoutSaga() {
    try {
        localStorage.removeItem("logged_user")
        yield put(closeChannelAction())

    } catch(e) {
        console.error(e)
    }
}

export function* watchLoginSaga() {
    yield takeLatest(types.LOGIN_REQUEST, loginSaga)
    yield takeLatest(types.REGISTER_REQUEST, registerSaga)
    yield takeLatest(types.LOGOUT_REQUEST, logoutSaga)
}