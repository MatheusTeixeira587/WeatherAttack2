import { HubConnectionBuilder, LogLevel } from "@aspnet/signalr";
import { eventChannel } from "redux-saga";
import { challengeEvents, types } from "../../constants";

const challengeChannel = "challenge";

export class HubService {

    static connect(token, channel) {
        const connection =  new HubConnectionBuilder()
            .withUrl(process.env.REACT_APP_API_URL + channel, { accessTokenFactory: () => token })
            .configureLogging(LogLevel.Information)
            .build();

        return new Promise(resolve => {
            connection.start()
                .then(() => resolve(connection))
        })
    }

    
    static createHubChannel(hub) {
        return eventChannel(emit => {
            const eventHandler = event => {
                emit(event);
            };

            const channelName = hub.connection.baseUrl.split('/').pop();

            if (channelName === challengeChannel) {
                hub = HubService._subscribeToChallengeEvents(hub, eventHandler);
            }

            debugger
            console.log(hub);

            return () => hub.off(types.STOP_CHANNEL);
        });
    }

    static _subscribeToChallengeEvents(hub, eventHandler) {

        Object.keys(challengeEvents)
            .forEach(prop => {
                hub.on(prop, (payload) => eventHandler({
                    type: prop,
                    payload: payload
                }))
            });

        return hub;
    }
}