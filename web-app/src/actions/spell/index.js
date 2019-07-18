import { types } from "../../constants"

export const addSpellAction = spell => {
    return {
        type: types.ADD_SPELL,
        spell
    }
}