import { types } from '../../constants';

export const addNotificationAction = (object) => ({
    type: types.ADD_NOTIFICATION,
    notification: object
})

export const removeNotificationAction = (object) => ({
    type: types.REMOVE_NOTIFICATION,
    notification: object
})