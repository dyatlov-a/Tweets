import Vue from 'vue';
import App from './app.vue';

import BootstrapVue from 'bootstrap-vue';
import './styles/bootstrap-settings.scss';
Vue.use(BootstrapVue);

import VeeValidate from 'vee-validate';
Vue.use(VeeValidate);

import vuePlugin from './system/vuePlugins'
Vue.use(vuePlugin);

import store from './store/index';

new Vue({
	el: '#app',
	store,
	render: h => h(App)
});
