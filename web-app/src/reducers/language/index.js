import { types, supportedLanguages } from "../../constants"

const initialState = {
    selected: supportedLanguages.EN_US,
}       
    
export function languageReducer(state = initialState, action) {
    switch(action.type) {

        case types.CHANGE_LANGUAGE:
            return Object.assign({}, {...state}, {
                selected: action.language,
            })

        default:
            return state
    }
}