import Vue from "vue";
import VueRouter from "vue-router";
import store from "../store/index";
import Home from "../views/Home.vue";
import Profile from "../components/users/Profile.vue";
import Signin from "../components/users/Signin.vue";
import Login from "../views/Login.vue";
import Logout from "../views/Logout.vue";
import Quyen_menu from "../views/Quyen_menu.vue";
import Quyen_baocao from "../views/Quyen_baocao.vue";
import Dashboard from "../views/Dashboard.vue";
import Rasoat_thuebao from "../views/Rasoat_thuebao.vue";
import kiemtra_session from "../services/Kiemtra_Session";
import Thongbao_I8 from "../views/Thongbao_I8";
import Error from "../views/Error";
import { VRating } from "vuetify/lib";

Vue.use(VueRouter);
const routes = [
  {
    path: "/home",
    name: "Home",
    component: Home,
    meta: { requiresAuth: true,title: "Home" },
  },
  // {
  //   path: "*",
  //   name: "Home",
  //   component: Home,
  //   meta: { requiresAuth: true,title: "Home" },
  // },
  {
    path: "/dashboard",
    name: "Dashboard",
    component: Dashboard,
    meta: { requiresAuth: true,title: "Dashboard" },
  },
  {
    path: "/about",
    name: "About",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/About.vue"),
    meta: { requiresAuth: true, title: "About" },
  },
  {
    path: "/profile",
    name: "Profile",
    component: Profile,
    meta: { requiresAuth: true,title: "Profile" },
  },
  {
    path: "/role_menu",
    name: "Role_menu",
    component: Quyen_menu,
    meta: { requiresAuth: true,title: "Quyền menu" },
  },
  {
    path: "/role_baocao",
    name: "Role_baocao",
    component: Quyen_baocao,
    meta: { requiresAuth: true,title: "Quyền báo cáo" },
  },
  {
    path: "/rasoat_thuebao",
    name: "Rasoat_thuebao",
    component: Rasoat_thuebao,
    meta: { requiresAuth: true,title: "Rà soát thuê bao" },
  },
  {
    path: "/thongbao_i8",
    name: "Thongbao_I8",
    component: Thongbao_I8,
    meta: { requiresAuth: true,title: "Thông báo I8" },
  },
  {
    path: "/signin",
    name: "Signin",
    component: Signin,
    meta: {},
  },
  {
    path: "/erro",
    name: "Error",
    component: Error,
    meta: {},
  },
  // {
  //   path: "/login",
  //   name: "Login",
  //   component: Login,
  //   meta: { allowAnonymous: true, title: "Login" },
  // },
  {
    path: "/logout",
    name: "Logout",
    component: Logout,
  },
  {
    path: "/",
    name: "Login",
    component: Login,
    meta: { allowAnonymous: true, title: "Login" },
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  const kt=kiemtra_session;
  var links = localStorage.ds_chucnang ? JSON.parse(localStorage.ds_chucnang) : '';
  if (to.matched.some((record) => record.meta.requiresAuth)) {
    if (kt.get_token_session()) {
      if(links && kt.kiemtra_link_truycap(links,to.path))
        next();
      else{
        return;
      }
    }else
      next("/");
  } else {
    next();
  }

  
  
  
  
});

// router.beforeEach((to, from, next) => {
//   if (to.matched.some((record) => record.meta.allowAnonymous)) {
//     if (store.getters.isAuthenticated) {
//       next("/about");
//       return;
//     }
//     next();
//   } else {
//     next();
//   }
// });
router.beforeEach((to, from, next) => {
  /* It will change the title when the router is change*/
  // const publicPages = ["/login", "/"];
  // const authRequired = !publicPages.includes(to.path);
  // const loggedIn = localStorage.getItem("user");
  if (to.meta.title) {
    document.title = to.meta.title;
  }
  next();
  // if (authRequired && !loggedIn) {
  // if (!loggedIn) {
  //   next("/login");
  // } else {
  //   next();
  // }
});
export default router;
