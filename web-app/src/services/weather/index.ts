import { BaseService } from "../_base"

export class WeatherService extends BaseService {

    constructor() {
        super("api/Weather")
    }

    async get(command: {latitude: number, longitude: number}) {
        const result = await this.post({
            Latitude: command.latitude,
            Longitude: command.longitude,
            Result: {}
        });

        return result.result;
    }
}