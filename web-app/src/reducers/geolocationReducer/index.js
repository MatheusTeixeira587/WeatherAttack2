import { types } from "../../constants"

const initialState = {
    latitude:"",
    longitude:""
}

export function geolocationReducer(state = initialState, action) {

    switch(action.type) {

        case types.ASSIGN_LOCATION:
            const location = action.location
            return Object.assign({}, {...state}, {
                latitude: location.latitude,
                longitude: location.longitude,
            })

        default:
            return state
    }
}