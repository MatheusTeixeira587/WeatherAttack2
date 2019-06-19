import { takeLatest, call, select } from "redux-saga/effects";
import { types } from "../../constants";
import { SpellService } from "../../services";

const spellService = new SpellService();

function* addSpellSaga(action){
    const token = yield select(state => state.loginReducer.token);  
    const response = yield spellService.put({spell: action.spell}, token);
}

export function* watchSpellSaga() {
    yield takeLatest(types.ADD_SPELL, addSpellSaga);
}