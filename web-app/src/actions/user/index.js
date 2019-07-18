import { types } from "../../constants"

export const getPagedUsersAction = command => {
    return {
        type: types.GET_PAGED_USERS,
        command
    }
}

export const assignPagedUserAction = result => {
    return { 
        type: types.ASSIGN_PAGED_USERS,
        payload: result
    }
}

export const changeRowsPerPageAction = rows => {
    return {
        type: types.CHANGE_ROWS_PAGE,
        rows
    }
}