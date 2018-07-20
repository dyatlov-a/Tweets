import { HTTP } from '../../system/httpRequest'
import { TWEETS_API_URL } from '../../system/api'
import { 
    TWEETS_SET_TAG, 
    TWEETS_SET_ITEMS,
    LOADING,
    LOADED,
    TWEETS_LOAD,
    TWEETS_UPDATE
} from '../consts'

const state = {
    tag: '',
    items: []
}

const mutations = {
    [TWEETS_SET_TAG](state, tag) {
        state.tag = tag;
    },
    [TWEETS_SET_ITEMS](state, items){
        state.items = items;
    }
}

const actions = {
    [TWEETS_LOAD]({ commit }) {
        return HTTP.get(TWEETS_API_URL).then(r => {
            commit(TWEETS_SET_TAG, r.data.tag);
            commit(TWEETS_SET_ITEMS, r.data.tweets);
        });
    },
    [TWEETS_UPDATE]({ state, commit }) {
        commit(LOADING);
        commit(TWEETS_SET_ITEMS, []);
        return HTTP.post(TWEETS_API_URL, { value: state.tag }).then(() => {
            return HTTP.get(TWEETS_API_URL).then(r => {
                commit(TWEETS_SET_ITEMS, r.data.tweets);
            });
        }).finally(() => commit(LOADED));
    }
}

export default {
    state,
    mutations,
    actions
}