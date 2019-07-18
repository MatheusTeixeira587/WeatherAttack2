import { types } from "../../constants";

export const changeLanguageAction = language => ({
    type: types.CHANGE_LANGUAGE,
    language: language
})