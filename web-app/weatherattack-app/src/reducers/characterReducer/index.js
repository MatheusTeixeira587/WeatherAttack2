import { types } from "../../constants";

const initialState = {
    battles: 0,
    wins: 0,
    losses: 0,
    medals: 0,
}

export function characterReducer(state = initialState, action) {

    switch (action.type) {
        
        case (types.ASSIGN_CHARACTER):
            return Object.assign({}, state, {
                battles: action.character.battles,
                wins: action.character.wins,
                losses: action.character.losses,
                medals: action.character.medals
            })

        default:
            return state;
    }
}