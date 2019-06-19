import { types } from '../../constants';

export const addRuleAction = rule => ({
    type: types.ADD_RULE,
    rule
})

export const removeRuleAction = key => ({
    type: types.REMOVE_RULE,
    id: key
})

export const changeRuleAction = (event, key) => ({
    type: types.CHANGE_RULE,
    fieldname: event.target.name,
    value: event.target.value,
    key
})