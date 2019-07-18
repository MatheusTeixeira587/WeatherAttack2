const NONE = { name: {
    EN_US: "None",
    PT_BR: "Nenhum"
}, value: 0 }
const FIRE = { name: {
    EN_US: "Fire",
    PT_BR: "Fogo"
}, value: 1 }
const ICE = { name: {
    EN_US: "Ice",
    PT_BR: "Gelo"
}, value: 2 }
const LIGHTNING = { name: {
    EN_US: "Lightning",
    PT_BR: "Raio"
}, value: 4 }
const WATER = { name: {
    EN_US: "Water",
    PT_BR: "Agua"
}, value: 8 }
const WIND = { name: {
    EN_US: "Wind",
    PT_BR: "Vento"
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