export class GeolocationService {

    async get() {

        if (navigator.geolocation) {

            const onSucess = (position, resolve) => {
                resolve({
                    latitude: position.coords.latitude,
                    longitude: position.coords.longitude,
                    error: null
                })
            }

            const onError = (error, resolve) => {
                resolve({
                    latitude: null,
                    longitude: null,
                    error: error
                })
            }

            return new Promise((resolve) => {
                navigator.geolocation.getCurrentPosition((res) => onSucess(res, resolve), (err) => onError(err, resolve))
            })
        }
    }
}