import { ADD_NOTIFICATION, REMOVE_NOTIFICATION } from '../../constants';

export const addNotificationAction = (object) => ({
    type: ADD_NOTIFICATION,
    notification: object
})

export const removeNotificationAction = (object) => ({
    type: REMOVE_NOTIFICATION,
    notification: object
})