import { types } from "../../constants"

const initialState = {
    rules: []
}

export function rulesReducer(state = initialState, action) {

    switch(action.type) {

        case types.ADD_RULE:
            return Object.assign({}, state, {
                rules: [...state.rules, action.rule]
            })

        case types.REMOVE_RULE:
            const newList = state.rules.filter((i,k) => k!== action.id) 
            return Object.assign({}, {...state}, {
                rules: newList
            })

        case types.CHANGE_RULE:
            const rules = [...state.rules]
            rules[action.key][action.fieldname] = action.value
        
            return Object.assign({}, {...state}, {
                rules
            })

        default:
            return state
    }
}