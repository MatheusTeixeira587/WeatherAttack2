const NONE = { name: {
    en_us: "None",
    pt_br: "Nenhum"
}, value: 0 }
const FIRE = { name: {
    en_us: "Fire",
    pt_br: "Fogo"
}, value: 1 }
const ICE = { name: {
    en_us: "Ice",
    pt_br: "Gelo"
}, value: 2 }
const LIGHTNING = { name: {
    en_us: "Lightning",
    pt_br: "Raio"
}, value: 4 }
const WATER = { name: {
    en_us: "Water",
    pt_br: "Agua"
}, value: 8 }
const WIND = { name: {
    en_us: "Wind",
    pt_br: "Vento"
}, value: 16 }

export const elements = {
    NONE,
    FIRE,
    ICE,
    LIGHTNING,
    WATER,
    WIND
}

export const elementList = [
    NONE,
    FIRE,
    ICE,
    LIGHTNING,
    WATER,
    WIND
]

export const ADD_SPELL = "ADD_SPELL"

export const GET_PAGED_SPELLS = "GET_PAGED_SPELLS"

export const ASSIGN_PAGED_SPELLS = "ASSIGN_PAGED_SPELLS"