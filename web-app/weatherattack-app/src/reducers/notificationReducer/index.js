import { types } from '../../constants';

const initialState = {
    notifications: []
}

export function notificationReducer(state = initialState, action) {
    
    switch(action.type) {

        case types.ADD_NOTIFICATION:
            const addNotification = () => {

                const newList = state.notifications;

                action.notification.forEach(n => newList.push(n))

                return { notifications: newList };
            }

            return Object.assign({}, state, addNotification());

        case types.REMOVE_NOTIFICATION:
            const removeNotification = () => {
                
                let newList = state.notifications;

                if(!newList.length) {
                    return [];
                }
                
                newList = newList.filter(n => !action.notification.map(n => n.code).includes(n.code));
                
                return { notifications: newList };
            }

            return Object.assign({}, state, removeNotification());
        
        default:
            return state;
    }
}