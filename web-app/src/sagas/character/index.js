import { CharacterService } from '../../services';
import { select, put, takeLatest } from 'redux-saga/effects';
import { assignCharacterAction } from '../../actions';
import { types } from '../../constants';

const characterService = new CharacterService();

function* getCharacterSaga() {

    try {  
        const loginState =  yield select(state => state.loginReducer);
        const response = yield characterService.getById(loginState.id, loginState.token);
        yield put(assignCharacterAction(response.result));
        
    } catch(e) {
        console.error(e);
    }
}

export function* watchGetCharacterSaga() {
    yield takeLatest(types.GET_CHARACTER, getCharacterSaga);
}