import { types } from "../../constants";

const initialState = {
    showLoader: false,
}       
    
export function loaderReducer(state = initialState, action) {
    switch(action.type) {

        case types.SHOW_LOADER:
            return Object.assign({}, {...state}, {
                showLoader: true,
            })

        case types.HIDE_LOADER:
            return Object.assign({}, {...state}, {
                showLoader: false,
            })

        default:
            return state;
    }
}