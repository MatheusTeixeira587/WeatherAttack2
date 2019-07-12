import { types } from '../../constants';

export const assignWeatherDataAction = (weather) => ({
    type: types.ASSIGN_WEATHER_DATA,
    weather: weather
})