import { types } from "../../constants"

export const getCharacterAction = () => ({
    type: types.GET_CHARACTER
})

export const assignCharacterAction = character => ({
    type: types.ASSIGN_CHARACTER,
    character
})