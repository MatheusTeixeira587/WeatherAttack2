import { combineReducers } from "redux"
import { loaderReducer } from "./loaderReducers"
import { loginReducer } from "./loginReducer"
import { notificationReducer } from "./notificationReducer"
import { geolocationReducer } from "./geolocationReducer" 
import { weatherReducer } from "./weatherReducer"
import { challengeReducer } from "./challengeReducer"
import { characterReducer } from "./characterReducer"
import { rulesReducer } from "./rulesReducer"
import { userAreaReducer } from "./userAreaReducer"
import { languageReducer } from "./language"

const rootState = combineReducers({
    loaderReducer,
    loginReducer,
    notificationReducer,
    geolocationReducer,
    weatherReducer,
    challengeReducer,
    characterReducer,
    rulesReducer,
    userAreaReducer,
    languageReducer
})

export default rootState