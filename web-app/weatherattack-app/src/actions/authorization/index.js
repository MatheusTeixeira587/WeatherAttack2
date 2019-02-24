import { AUTHORIZED, UNAUTHORIZED } from "../../constants";

export const setAuthorizedAction = () => ({
    type: AUTHORIZED
})

export const setUnauthorizedAction = () => ({
    type: UNAUTHORIZED
})