import { ASSIGN_LOCATION } from "../../constants";

const initialState = {
    latitude:"",
    longitude:""
}

export function geolocationReducer(state = initialState, action) {

    switch(action.type) {

        case ASSIGN_LOCATION:
            const location = action.location;

            return Object.assign({}, state, {
                latitude: location.latitude,
                longitude: location.longitude,
                error: location.error
            })

        default:
            return state;
    }
}