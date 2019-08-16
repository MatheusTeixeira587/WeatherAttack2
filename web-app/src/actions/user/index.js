import { types } from "../../constants"

export const getPagedUsersAction = command => {
    return {
        type: types.GET_PAGED_USERS,
        command
    }
}

export const assignPagedUserAction = command => {
    return { 
        type: types.ASSIGN_PAGED_USERS,
        command
    }
}

export const changeRowsPerPageAction = command => {
    return {
        type: types.CHANGE_ROWS_PAGE,
        command
    }
}