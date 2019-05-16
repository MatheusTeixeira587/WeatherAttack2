import { challengeEvents } from "../../constants";

const initialState = {
    loggedUsers: []
}

export function challengeReducer(state = initialState, action) {

    switch (action.type) {

        case challengeEvents.USER_LEFT_CHANNEL:
            const new_users = state.loggedUsers.filter(u => u.id !== action.payload.id)
            
            return Object.assign({},state, {
                loggedUsers: new_users
            });

        case challengeEvents.USER_JOINED_CHANNEL:
            const users = state.loggedUsers;
            users.push(action.payload)
            
            return Object.assign({},state, {
                loggedUsers: users
            });


        default:
            return state;
    }
}