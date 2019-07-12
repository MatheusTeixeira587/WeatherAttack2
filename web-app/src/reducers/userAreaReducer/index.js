import { types } from '../../constants';

const initialState = {
    pageCount: 0,
    pageSize: 20,
    pageNumber: 1,
    users: [],
    totalRecords: 0
}

export function userAreaReducer(state = initialState, action) {

    switch(action.type) {
        case types.ASSIGN_PAGED_USERS:
            return Object.assign({}, {
                users: action.payload.result,
                pageNumber: action.payload.pageNumber,
                pageCount: action.payload.pageCount,
                pageSize: action.payload.pageSize,
                totalRecords: action.payload.totalRecords
            })

        case types.CHANGE_ROWS_PAGE:
            return Object.assign({}, state, {
                pageSize: action.rows
            })
            
        default:
            return state;
    }
}