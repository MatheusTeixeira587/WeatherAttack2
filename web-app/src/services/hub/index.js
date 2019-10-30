import { HubConnectionBuilder, LogLevel } from "@aspnet/signalr"
import { eventChannel } from "redux-saga"
import { challengeEvents } from "../../constants"
import { requestLogoutAction } from "../../actions"

const challengeChannel = "challenge"

export class HubService {

    static async connect(token, channel) {
        const connection =  new HubConnectionBuilder()
            .withUrl(process.env.REACT_APP_API_URL + channel, { accessTokenFactory: () => token })
            .withAutomaticReconnect()
            .configureLogging(LogLevel.Information)
            .build()

        await connection.start();

        return connection;
    }

    
    static createHubChannel(hub) {
        return eventChannel(emit => {
            const eventHandler = event => {
                emit(event)
            }

            const channelName = hub.connection.baseUrl.split("/").pop()

            if (channelName === challengeChannel) {
                hub = HubService._subscribeToChallengeEvents(hub, eventHandler)
            }

            hub.onclose(e => eventHandler(requestLogoutAction()))

            return () => hub
        })
    }

    static _subscribeToChallengeEvents(hub, eventHandler) {

        Object.keys(challengeEvents)
            .forEach(prop => {
                hub.on(prop, (command) => eventHandler({
                    type: prop,
                    command
                }))
            })

        return hub
    }
}