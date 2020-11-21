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
    items_user:[]
  },
  getters: {
    return_items_user: state => {
      return state.items_user
    }
 
  },
  mutations: {
    get_items_user (state, payload) {
      state.items_user = payload
    }
 
  },
  actions: {}

});
