import { types } from "../../constants"

export const addSpellAction = spell => {
    return {
        type: types.ADD_SPELL,
        spell
    }
}

export const getPagedSpellsAction = command => {
    return {
        type: types.GET_PAGED_SPELLS,
        command
    }
}

export const assignPagedSpells = command => {
    return {
        type: types.ASSIGN_PAGED_SPELLS,
        command
    }
}