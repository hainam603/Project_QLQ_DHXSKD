import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import axios from "axios";
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import 'element-ui/lib/theme-chalk/reset.css';
import locale from 'element-ui/lib/locale/lang/vi';
import XLSX from 'xlsx'


// axios.defaults.withCredentials = true;
axios.defaults.baseURL = "https://localhost:5000/api/";

Vue.config.productionTip = false;
Vue.use(ElementUI, { locale })
Vue.use(XLSX)

new Vue({
  router,
  store,
  vuetify,
  render: (h) => h(App),
}).$mount("#app");
