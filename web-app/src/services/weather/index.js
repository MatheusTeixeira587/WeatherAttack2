import { BaseService } from "../_base"

export class WeatherService extends BaseService {

    constructor() {
        super("api/Weather")
    }

    get(command) {
        return this.post({
            Latitude: command.latitude,
            Longitude: command.longitude,
            Result: {}
        }).then((result) => result.result)
    }
}