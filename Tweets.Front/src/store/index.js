import Vue from 'vue'
import Vuex from 'vuex'

import tweets from './modules/tweets'
import loading from './modules/loading'

Vue.use(Vuex)

const store = new Vuex.Store({
	modules: {
		tweets,
		loading
	}
});

export default store