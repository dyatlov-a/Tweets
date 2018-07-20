import { LOADING, LOADED } from '../consts'

const state = {
    isReady: false
}

const mutations = {
    [LOADING](state) {
        state.isReady = false;
    },
    [LOADED](state) {
        state.isReady = true;
    }
}

export default {
    state,
    mutations
}