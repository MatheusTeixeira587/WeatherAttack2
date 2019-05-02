import { ASSIGN_WEATHER_DATA } from '../../constants';

export const assignWeatherDataAction = (weather) => ({
    type: ASSIGN_WEATHER_DATA,
    weather: weather
})