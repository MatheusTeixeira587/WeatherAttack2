import { challengeEvents, types } from "../../constants"

const initialState = {
    loggedUsers: [],
    invites: []
}

export function challengeReducer(state = initialState, action) {

    switch (action.type) {

        case challengeEvents.USER_LEFT_CHANNEL:
            const new_users = state.loggedUsers.filter(u => u.id !== action.command.id)
            
            return Object.assign({},{...state}, {
                loggedUsers: new_users
            })

        case challengeEvents.USER_JOINED_CHANNEL:
            const users = state.loggedUsers
            users.push(action.command)
            
            return Object.assign({},{...state}, {
                loggedUsers: users
            })

        case challengeEvents.GET_ONLINE_USERS:
            return Object.assign({}, {...state}, {
                loggedUsers: action.command
            })

        case types.USER_RECEIVED_CHALLENGE:
            return Object.assign({}, state, {
                invites: [...state.invites, action.command]
            })

        case types.REMOVE_CHALLENGE:
            debugger
            const filterChallenges = action => {
                return {
                    invites: [...state.invites].filter(i => i.id !== action.command.id)
                }
            }

            return Object.assign({}, state, filterChallenges(action))

        default:
            return state
    }
}