import { ASSIGN_WEATHER_DATA } from '../../constants';

const initialState = {
    cityName:"",
    weather:[],
    main:"",
    wind:"",
    countryInfo:{name:""},
    rain:""
}

export function weatherReducer(state = initialState, action) {

    switch(action.type) {
        case ASSIGN_WEATHER_DATA:
            const weather = action.weather
            return Object.assign({}, state,{
                cityName: weather.cityName,
                weather: weather.weather,
                main: weather.main,
                wind: weather.wind,
                countryInfo: weather.countryInfo,
                rain: weather.rain
            })

        default:
            return state;
    }
}