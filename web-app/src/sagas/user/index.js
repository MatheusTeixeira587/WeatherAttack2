import { takeLatest, select, put } from "redux-saga/effects";
import { types } from "../../constants";
import { UserService } from "../../services";
import { assignPagedUserAction } from "../../actions";

const userService = new UserService();

function* getPagedUserSaga(action) {
    const token = yield select(state => state.loginReducer.token);
    try {
        const response = yield userService.pagedGet(token, action.command.pageNumber);
        yield put(assignPagedUserAction(response));

    } catch (e) {
        console.log(e);
    }
    
}

export function* watchUserSaga() {
    yield takeLatest(types.GET_PAGED_USERS, getPagedUserSaga);
}