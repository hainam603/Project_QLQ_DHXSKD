import Vue from "vue";
import Vuex from "vuex";
import auth from "./modules/auth";

// Load Vuex
Vue.use(Vuex);

// Create store
export default new Vuex.Store({
  modules: {
    auth,
  },
  state: {
    items_user:[],
    headers_user: [
      { text: '', value: 'stt'},
      { text: 'Mã ND', value: 'ma_ND'},
      { text: 'Tên NV', value: 'ten_NV' },
      { text: 'Đơn vị', value: 'ten_dv' },
    ],
  },
  getters: {
    return_items_user: state => {
      return state.items_user
    },
    return_headers_user: state => {
      return state.headers_user
    }
 
  },
  mutations: {
    get_items_user (state, payload) {
      state.items_user = payload
      debugger;
    }
 
  },
  actions: {}

});
