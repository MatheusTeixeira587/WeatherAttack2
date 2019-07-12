import { takeLatest, select } from "redux-saga/effects";
import { types } from "../../constants";
import { SpellService } from "../../services";

const spellService = new SpellService();

function* addSpellSaga(action){
    const token = yield select(state => state.loginReducer.token);
    try {
        yield spellService.put(action, token);
    } catch (e) {
        console.log(e);
    }
}

export function* watchSpellSaga() {
    yield takeLatest(types.ADD_SPELL, addSpellSaga);
}