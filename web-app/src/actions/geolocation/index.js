import { types } from "../../constants"

export const getLocationAction = () => ({
    type: types.GET_LOCATION
})

export const assignLocationAction = location => ({
    type: types.ASSIGN_LOCATION,
    location: location
})