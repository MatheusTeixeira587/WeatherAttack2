import { AUTHORIZED } from "../../constants";
import { UNAUTHORIZED } from "../../constants"

const initialState = {
    authorized: false,
}

export function authorizationReducer(state = initialState, action){
    switch(action.type) {

        case AUTHORIZED:
            return Object.assign({}, state, {
                authorized:true,
            })

        case UNAUTHORIZED:
            return Object.assign({}, state, {
                authorized:false,
            })

        default:
            return state;
    }
}