import { types } from "../../constants"

export const userReceivedChallengeAction = command => ({
    type: types.USER_RECEIVED_CHALLENGE,
    command
})