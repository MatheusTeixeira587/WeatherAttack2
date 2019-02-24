import { AUTHORIZED, UNAUTHORIZED } from "../../constants";

export const setAuthorized = () => ({
    type: AUTHORIZED
})

export const setUnauthorized = () => ({
    type: UNAUTHORIZED
})