import { HubConnectionBuilder, LogLevel, HubConnection } from "@aspnet/signalr"
import { eventChannel } from "redux-saga"
import { challengeEvents } from "../../constants"
import { requestLogoutAction } from "../../actions"

const challengeChannel = "challenge"

export class HubService {

    static async connect(token: string, channel: string) {
        const connection =  new HubConnectionBuilder()
            .withUrl(process.env.REACT_APP_API_URL + channel, { accessTokenFactory: () => token })
            .configureLogging(LogLevel.Information)
            .build()

        await connection.start();

        return connection;
    }

    
    static createHubChannel(hub: HubConnection, channel: string) {
        return eventChannel(emit => {
            const eventHandler = (event: { type: string }) => {
                emit(event)
            }

            if (channel === challengeChannel) {
                hub = HubService._subscribeToChallengeEvents(hub, eventHandler)
            }

            hub.onclose(e => eventHandler(requestLogoutAction()))

            return () => hub
        })
    }

    static _subscribeToChallengeEvents(hub: HubConnection, eventHandler: Function) {

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