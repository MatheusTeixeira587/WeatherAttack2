import { SHOW_LOADER, HIDE_LOADER } from "../../constants";

const initialState = {
    showLoader: false,
}       
    
export function loaderReducer(state = initialState, action) {
    switch(action.type) {

        case SHOW_LOADER:
            return Object.assign({}, state, {
                showLoader: true,
            })

        case HIDE_LOADER:
            return Object.assign({}, state, {
                showLoader: false,
            })

        default:
            return state;
    }
}