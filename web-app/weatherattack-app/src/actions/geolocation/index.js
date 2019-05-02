import { GET_LOCATION, ASSIGN_LOCATION } from '../../constants'

export const getLocationAction = () => ({
    type: GET_LOCATION
})

export const assignLocationAction = (location) => ({
    type: ASSIGN_LOCATION,
    location: location
})