import { types, challengeEvents } from "../../constants"

export const userReceivedChallengeAction = command => ({
    type: types.USER_RECEIVED_CHALLENGE,
    command
})

export const userRefusedChallengeAction = command => ({
    type: challengeEvents.REFUSE_CHALLENGE,
    command
})

export const userAcceptedChallengeAction = command => ({
    type: challengeEvents.ACCEPT_CHALLENGE,
    command
})

export const removeChallengeAction = command => ({
    type: types.REMOVE_CHALLENGE,
    command
})