import { challengeEvents, types } from "../../constants"

const initialState = {
    loggedUsers: []
}

export function challengeReducer(state = initialState, action) {

    switch (action.type) {

        case challengeEvents.USER_LEFT_CHANNEL:
            const new_users = state.loggedUsers.filter(u => u.id !== action.payload.id)
            
            return Object.assign({},{...state}, {
                loggedUsers: new_users
            })

        case challengeEvents.USER_JOINED_CHANNEL:
            const users = state.loggedUsers
            users.push(action.payload)
            
            return Object.assign({},{...state}, {
                loggedUsers: users
            })

        case challengeEvents.GET_ONLINE_USERS:
            return Object.assign({}, {...state}, {
                loggedUsers: action.payload
            })

        case types.USER_RECEIVED_CHALLENGE:
            return Object.assign({}, state, action.command)

        default:
            return state
    }
}