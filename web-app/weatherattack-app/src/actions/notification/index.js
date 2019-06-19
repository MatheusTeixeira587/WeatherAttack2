import { types } from '../../constants';
import { isArray } from 'util';

export const addNotificationAction = (object) => {
    return {
        type: types.ADD_NOTIFICATION,
        notification: isArray(object) ? object : [object]
    }
}

export const removeNotificationAction = (object) => {
    return {
        type: types.REMOVE_NOTIFICATION,
        notification: isArray(object) ? object : [object]
    }
}