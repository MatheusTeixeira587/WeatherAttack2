import { types, challengeEvents } from '../../constants'

export const startChannelAction = () => ({
    type: types.START_CHANNEL
})

export const closeChannelAction = () => ({
    type: types.STOP_CHANNEL
})

export const sendChallengeAction = command => ({
    type: challengeEvents.CHALLENGE_USER,
    command
})

export const acceptChallengeAction = command => ({
    type: challengeEvents.ACCEPT_CHALLENGE,
    command
})

export const refuseChallengeAction = command => ({
    type: challengeEvents.REFUSE_CHALLENGE,
    command
})