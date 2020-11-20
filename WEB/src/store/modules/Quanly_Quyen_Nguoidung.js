import axios from "axios";
// import router from '@/router';

const state = {
  token: localStorage.getItem("access_token") || null,
  user: null,
  loggedIn:false,
};

const getters = {
  loggedIn(state) {
    return state.token !== null;
  }
};

const actions = {
    lay_ds_nguoidung(context, user) {
    axios
      .post("nguoidung/lay_ds_nguoidung", {})
      .then((response) => {
        const token = response.data.token;
        const result = response.data;
        localStorage.setItem("access_token", token);
        context.commit("retrieveToke", token);
        context.commit("retrieveResult", result);
      })
      .catch((error) => {
        console.log(error);
      });
  },
  destroyToken(context) {
    localStorage.removeItem("access_token");
    context.commit("destroyToken");
  },


  async CreatePost({ dispatch }, post) {
    await axios.post("post", post);
    return await dispatch("GetPosts");
  },

  async GetPosts({ commit }) {
    let response = await axios.get("posts");
    commit("setPosts", response.data);
  },

  async LogOut({ commit }) {
    let user = null;
    commit("logout", user);
  },
};

const mutations = {
  setUser(state, username) {
    state.user = username;
  },

  setPosts(state, posts) {
    state.posts = posts;
  },
  logout(state, user) {
    state.user = user;
  },
  retrieveToke(state, token) {
    state.token = token;
  },
  destroyToken(state) {
    state.token = null;
    state.user = null;
  },
  retrieveResult(state, result) {
    state.user = result;
  },
};

export default {
  state,
  getters,
  actions,
  mutations,
};
